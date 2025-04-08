#include <mysql/mysql.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
//#include <my_global.h>

#define PORT 9053
#define MAX_PLAYERS 100

int contador;

//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i;
int sockets[100];

typedef struct {
	char nombre[20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados[MAX_PLAYERS];
	int numConectados;
} ListaConectados;

ListaConectados *listaConectados;

int PonerConectado(ListaConectados *listaConectados, char nombre[20], int socket) {
	if (listaConectados->numConectados>= MAX_PLAYERS) 
		return -1; // Lista llena
	else{
		strcpy(listaConectados->conectados[listaConectados->numConectados].nombre, nombre);
		listaConectados->conectados[listaConectados->numConectados].socket = socket;
		listaConectados->numConectados++;
		printf("Jugadores conectados (%d): ", listaConectados->numConectados);
		for (int i = 0; i < listaConectados->numConectados; i++) {
			printf("%s ", listaConectados->conectados[i].nombre);
		}
		printf("\n");
    return 0; // Jugador añadido correctamente
	}
}

int DamePosicion(ListaConectados *lista, char nombre[20]){

	//Devuelve popsicion o -1 sino esta en la lista
	int i = 0; 
	int encontrado = 0;
	while((i < lista->numConectados) && !encontrado)
	{
		if(strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado = 1;
		if(!encontrado)
			i = i+1;		   
	}
	if (encontrado)
		return i;
	else 
		return-1;
}

void DameConec(ListaConectados *lista, char nombres[50]){
	if (lista->numConectados == 0) {
		strcpy(nombres, "No hay jugadores conectados.");
		return;
	}
	
	sprintf(nombres, "%d", lista->numConectados);
	for (int i = 0; i < lista->numConectados; i++) {
		strcat(nombres, "/");
		strcat(nombres, lista->conectados[i].nombre);
	}
	
	printf("Lista de conectados enviada: %s\n", nombres);
}


int EliminarConectado(ListaConectados *lista, char nombre[20]) {
	//Devuelve -1 sino esta en la lista
	int posicion = DamePosicion(lista, nombre);
	if (posicion == -1)
		return -1;
	else {
		for (int i = posicion; i < lista->numConectados - 1; i++)
		{
			lista->conectados[i] = lista->conectados[i+1];
		}
		lista->numConectados--;
		return 0;
	}
}

void *AtenderCliente(void *socket) {
    int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
    char peticion[512];
    char respuesta[512];
	int ret;
	
	MYSQL *conn = mysql_init(NULL);
    if (!conn) {
        fprintf(stderr, "Error al crear la conexión MySQL\n");
        close(sock_conn);
        pthread_exit(NULL);
    }

    if (!mysql_real_connect(conn, "localhost", "root", "mysql", "memory", 0, NULL, 0)) {
        fprintf(stderr, "Error al conectar con MySQL: %s\n", mysql_error(conn));
        mysql_close(conn);
        close(sock_conn);
        pthread_exit(NULL);
    }

    int terminar = 0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
    while (terminar ==0) {
		
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
        
        
        // Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		printf ("Peticion: %s\n",peticion);

        // vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
        char usuario[20], contrasena[50], nombre[20];
        int edad;
		
		if ((codigo !=0)&&(codigo!=7))
			{
				p = strtok( NULL, "/");
			
				strcpy (usuario, p);
				// Ya tenemos el nombre
				printf ("Codigo: %d, Nombre: %s\n", codigo, usuario);
			}

        if (codigo ==0)
			{ //Peticion de desconexion		
				p = strtok(NULL, "/");
				strcpy(usuario, p);
				int res = EliminarConectado(&listaConectados, usuario);
				terminar=1;
	
				if (res == 0) 
					printf("Jugador eliminado de la lista de conectados.\n", usuario);
				else 
					printf("No se ha eliminado el usuario porque no existia en la lista\n", usuario);
			}
        else if (codigo == 1) {// Peticion de login
                p = strtok( NULL, "/");
				
				strcpy (contrasena, p);
				sprintf(respuesta,"1/%d",login(conn, usuario,contrasena));
				int res = PonerConectado(&listaConectados, usuario, sock_conn);
                if (res == 0 && login(conn, usuario,contrasena) == 1) {
                    printf("Jugador %s añadido a la lista de conectados.\n", usuario);
                } else {
                    printf("No se pudo añadir a %s: Lista llena.\n", usuario);
                }     
				
		} 
		else if (codigo == 2) {//Peticion de registro
                p = strtok( NULL, "/");
				
				strcpy (contrasena, p);
				sprintf(respuesta,"2/%d",register_player(conn, usuario,contrasena));
		
        } 
		else if (codigo == 3) //Peticion de mejor tiempo
                sprintf(respuesta,"3/%d",MejorTiempo(conn, usuario));
        else if (codigo == 4) //Peticion para consultar el nombre de jugadores que hay en la partida
				sprintf(respuesta,"4/%d",ConsultarNumJugadores(conn, usuario));   
	    else if (codigo==5)
			{// Peticion para modificar el perfil (por ahora nombre y edad)
                int edad;
				
				p = strtok( NULL, "/");
				strcpy (nombre, p);
				p = strtok( NULL, "/");
				edad = atoi(p);
				
				sprintf(respuesta,"5/%d",ModificarPerfil(conn, usuario,nombre,edad));
            }
		else if(codigo==6){
			char nombres[512];
			DameConec(&listaConectados, nombres);
			sprintf(respuesta, "6/%s", nombres);
		}
		
		if (codigo !=0)
			{
			
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
		
		if ((codigo ==1)||(codigo==2)|| (codigo==3)|| (codigo==4)|| (codigo==5)|| (codigo==6))
			{
				pthread_mutex_lock( &mutex ); //No me interrumpas ahora
				contador = contador +1;
				pthread_mutex_unlock( &mutex); //ya puedes interrumpirme
				// notificar a todos los clientes conectados
				char notificacion[20];
				sprintf (notificacion, "7/%d",contador);
				int j;
				for (j=0; j< i; j++)
					write (sockets[j],notificacion, strlen(notificacion));
			}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn);
	mysql_close(conn);
	pthread_exit(NULL);
}


int main(int argc, char *argv[]) {
    int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;

	// INICIALITZACIONS
	// Obrim el socket
    if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
        printf("Error creando socket.\n");

    
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	// establecemos el puerto de escucha
    serv_adr.sin_port = htons(PORT);

    if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind.\n");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen.\n");
	
	pthread_t thread;
	i=0;
	
	for (;;){
        printf("Esperando conexiones en el puerto %d\n", PORT);

        if ((sock_conn = accept(sock_listen, NULL, NULL)) < 0) {
            printf("Error en accept.\n");
        }
		else
        printf("Nueva conexión establecida.\n");
	
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente

        pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
    }

    close(sock_listen);
    return 0;
}

// Funciones de la base de datos
int login(MYSQL *conn, char *id_usuario, char *contrasena){
	char consulta[300];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy(consulta, "SELECT nombre FROM jugadores WHERE id_jugador = '");
	strcat(consulta, id_usuario);
	strcat(consulta, "' AND contrase�a = '");
	strcat(consulta, contrasena);
	strcat(consulta, "'");
	
	err = mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error al consultar la base de datos: %s\n", mysql_error(conn));
		return 0;
	}
	
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	
	if (row != NULL) {

		mysql_free_result(resultado);
		return 1;
	}
	
	mysql_free_result(resultado);
	return 0;
}
int register_player(MYSQL *conn, char *nuevo_id, char *contrasena){
	char consulta[300];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	// Verificar si el usuario ya existe
	strcpy(consulta, "SELECT id_jugador FROM jugadores WHERE id_jugador = '");
	strcat(consulta, nuevo_id);
	strcat(consulta, "'");
	
	err = mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error al consultar la base de datos: %s\n", mysql_error(conn));
		return 0;
	}
	
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	
	if (row != NULL) {
		
		mysql_free_result(resultado);
		return 0;
	}
	
	mysql_free_result(resultado);
	
	// Insertar nuevo jugador
	strcpy(consulta, "INSERT INTO jugadores (id_jugador, contrase�a) VALUES ('");
	strcat(consulta, nuevo_id);
	strcat(consulta, "', '");
	strcat(consulta, contrasena);
	strcat(consulta, "') ");

	
	err = mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error al registrar el jugador: %s\n", mysql_error(conn));
		return 0;
	}
	
	
	return 1;
}
int MejorTiempo(MYSQL *conn, char *id){
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta[200];
	
	strcpy(consulta, "SELECT MejorTiempo FROM jugadores WHERE id_jugador = '");
	strcat(consulta, id);
	strcat(consulta, "'");
	
	err = mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		return 1;
	}
	
	resultado = mysql_store_result(conn);
	if (resultado == NULL){
		return 1;
	}
	row = mysql_fetch_row(resultado);
	if (row[0] == NULL){
		return 1;
	}
	
	int mejorTiempo = atoi(row[0]);
	mysql_free_result(resultado);
	
	return mejorTiempo;
}
int ConsultarNumJugadores(MYSQL *conn, char *id_partida){
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[200];
	int err;
	int num_jugadores;
	
	strcpy(consulta, "SELECT CantidadJugadores FROM partida WHERE id_partida = '");
	strcat(consulta, id_partida);
	strcat(consulta, "'");
	
	err = mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	
	if (row[0] == NULL) {
		return -1;
	}else
		num_jugadores = atoi(row[0]);
	
	mysql_free_result(resultado);
	
	return num_jugadores;
}
int ModificarPerfil(MYSQL *conn, char *id_usuario, char *nombre, int *edad){
	MYSQL_RES *resultado;
	MYSQL_ROW row;

	char consulta[200];
	int err;
	char edadInput [10]; 
	sprintf(edadInput , "%d", edad);

	sprintf(consulta, "UPDATE jugadores SET nombre = '%s', edad = %s WHERE id_jugador = '%s'", 
			nombre, edadInput, id_usuario);

	err = mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error al actualizar la base de datos: %s\n", mysql_error(conn));
		return 0; 
	}
	

	if (mysql_affected_rows(conn) == 0) {
		printf("Error: El usuario con ID '%s' no existe en la base de datos.\n", id_usuario);
		return 0;  
	}
	
	return 1;
}
