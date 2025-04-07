DROP DATABASE IF EXISTS memory;
CREATE DATABASE memory;

USE memory;

CREATE TABLE jugadores(
    id_jugador VARCHAR(100) PRIMARY KEY NOT NULL,
    contraseña VARCHAR(100) NOT NULL,
    nombre TEXT,
    edad INT,
    MejorTiempo FLOAT,
    PartidasGIndividual INT,
    PartidasGEquipo INT,
    PartidasPIndividual INT,
    PartidasPEquipo INT 
) ENGINE=InnoDB;

CREATE TABLE partida(
    id_partida VARCHAR(100) PRIMARY KEY NOT NULL,
    CantidadJugadores INT NOT NULL,
    tiempopartida FLOAT NOT NULL
) ENGINE=InnoDB;

CREATE TABLE Participacion(
    id_par VARCHAR(100) NOT NULL,
    id_jug VARCHAR(100) NOT NULL,
    ganador VARCHAR(100) NOT NULL,
    PRIMARY KEY (id_par, id_jug),
    FOREIGN KEY (id_jug) REFERENCES jugadores(id_jugador),
    FOREIGN KEY (id_par) REFERENCES partida(id_partida)
) ENGINE=InnoDB;

CREATE TABLE baraja(
    id_carta INT PRIMARY KEY NOT NULL,
    accion VARCHAR(100) NOT NULL
) ENGINE=InnoDB;

-- Insertar en jugadores
INSERT INTO jugadores VALUES ('Nikito21','12345', 'Nicolas', 21, 96.5, 5, 2, 3, 1);

-- Insertar en partida
INSERT INTO partida VALUES ('Coches1', 2, 121.5);

-- Insertar en Participacion (debe coincidir con jugadores y partida)
INSERT INTO Participacion VALUES ('Coches1', 'Nikito21', 'SI');

-- Consultar las tablas para ver los datos insertados
SELECT * FROM jugadores;
SELECT * FROM partida;
SELECT * FROM Participacion;


