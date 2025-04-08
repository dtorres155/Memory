using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {
                    case 1:  //Respuesta al login

                        if (mensaje == "1")
                            MessageBox.Show("Bienvenido");
                        else
                            MessageBox.Show("No hemos encontrado su usuario o ha fallado la contraseña.");

                        break;
                    case 2:      //Respuesta al registro

                        if (Convert.ToInt32(mensaje) == 1)
                            MessageBox.Show("Se ha registrado correctamente");
                        else
                            MessageBox.Show("Usuario ya registrado anteriormente");
                        break;
                    case 3:       //Recibimos el mejor tiempo registrado
                        if (mensaje == "1")
                            MessageBox.Show("Todavía no hay un tiempo registrado");
                        else
                            MessageBox.Show(mensaje);
                        break;
                    case 4:     //Recibimos la cantidad de jugadores en la partida

                        if (mensaje == "-1")
                            MessageBox.Show("No hemos encontrado esta partida");
                        else
                            MessageBox.Show("Esta partida es para" + mensaje + "jugadores");
                        break;
                     case 5:  //Respuesta a la modificación del perfil
                        if (mensaje == "1")
                            MessageBox.Show("Se ha modificado correctamente");
                        else
                            MessageBox.Show("No se ha podido modificar");
                        break;
                    case 6: 
                        break;
                    case 7: //Recibimos notificacion
                        contLbl.Text = mensaje;
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(IPBox.Text);
            IPEndPoint ipep = new IPEndPoint(direc, Convert.ToInt32(PortBox.Text));
            

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";
        
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Mensaje de login
            string mensaje = "1/" + UserBox.Text + "/" + PasswordBox.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            //Mensaje de login
            string mensaje = "2/" + UserBox.Text + "/" + PasswordBox.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string mensaje = "3/" + UserBox.Text ;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Enviamos id_partida
            string mensaje = "4/" + partida.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            string mensaje = "5/" + UserBox.Text + "/" + nombre.Text + "/" + edad.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


        }
    }
}
