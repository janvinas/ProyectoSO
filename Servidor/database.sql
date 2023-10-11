DROP DATABASE IF EXISTS AirportSIM;
CREATE DATABASE AirportSIM;
USE AirportSIM;
CREATE TABLE Jugador(
	ID INTEGER PRIMARY KEY NOT NULL,
	Usuario TEXT NOT NULL,
	Password TEXT NOT NULL,
	Mail TEXT NOT NULL,
	Genero CHAR NOT NULL
);

CREATE TABLE Partidas(
	ID INTEGER PRIMARY KEY NOT NULL,
	Hinicio DATETIME NOT NULL,
	Hfin DATETIME,
	TimePlayed FLOAT NOT NULL
);

CREATE TABLE Jug_Part(
	Jugador INTEGER NOT NULL,
	Partida INTEGER NOT NULL,
	Dinero INTEGER NOT NULL,
	FOREIGN KEY (Jugador) REFERENCES Jugador(ID),
	FOREIGN KEY (Partida) REFERENCES Partidas(ID)
);

CREATE TABLE Logros (
	ID INTEGER PRIMARY KEY NOT NULL, 
	descripcion VARCHAR(50) NOT NULL,
	recompensa INTEGER NOT NULL
	);

CREATE TABLE Jug_Log (
	ID_Jugadores INTEGER, 
	ID_Logro INTEGER, 
	logro_obtenido VARCHAR(3), 
	recompensa_obtenida VARCHAR(3), 
	FOREIGN KEY (ID_Jugadores) REFERENCES Jugador(ID),
  	FOREIGN KEY (ID_Logro) REFERENCES Logros(ID)
 	);

CREATE TABLE Construcciones (
	ID INTEGER PRIMARY KEY NOT NULL,
	nombre VARCHAR(50) NOT NULL,
	precio INTEGER NOT NULL
);

CREATE TABLE Part_Const (
	ID_Part INTEGER,
	ID_Const INTEGER,
	X INTEGER,
	Y INTEGER,
	Nivel INTEGER,
	FOREIGN KEY (ID_Part) REFERENCES Partidas(ID),
	FOREIGN KEY (ID_Const) REFERENCES Construcciones(ID)
);

INSERT INTO Jugador VALUE(1,'PauSerrano','pauserrano','pau.serrano@gmail.com','M');
INSERT INTO Jugador VALUE(2,'CarlosMunoz','carlosmunoz','carlos.munoz@gmail.com','M');
INSERT INTO Jugador VALUE(3,'JanVinas','janvinas','jan.vinas@gmail.com','M');

INSERT INTO Partidas (ID, Hinicio, TimePlayed) VALUES (1, '2023-09-03 17:09:00', 0);
INSERT INTO Partidas (ID, Hinicio, TimePlayed) VALUES (2, '2023-09-15 22:15:00', 0);
INSERT INTO Partidas (ID, Hinicio, TimePlayed) VALUES (3, '2023-09-27 02:15:00', 0);
INSERT INTO Partidas (ID, Hinicio, TimePlayed) VALUES (4, '2023-09-03 17:09:00', 0);
INSERT INTO Partidas (ID, Hinicio, TimePlayed) VALUES (5, '2023-09-15 22:15:00', 0);
INSERT INTO Partidas (ID, Hinicio, TimePlayed) VALUES (6, '2023-09-27 02:15:00', 0);

INSERT INTO Jug_Part VALUES (1,1,20);
INSERT INTO Jug_Part VALUES (1,4,10);
INSERT INTO Jug_Part VALUES (1,6,5);
INSERT INTO Jug_Part VALUES (2,2,0);
INSERT INTO Jug_Part VALUES (3,3,40);
INSERT INTO Jug_Part VALUES (3,5,50);

INSERT INTO Construcciones VALUES (1, 'Pista de Aterrizaje', 100000000);
INSERT INTO Construcciones VALUES (2, 'Terminal', 70000000);
INSERT INTO Construcciones VALUES (3, 'Aparcamiento', 1500000);
INSERT INTO Construcciones VALUES (4, 'Torre de Control', 4000000);

INSERT INTO Part_Const VALUES (1, 1, 30, 55, 4);
INSERT INTO Part_Const VALUES (1, 2, 30, 35, 3);
INSERT INTO Part_Const VALUES (2, 1, 10, 10, 2);
INSERT INTO Part_Const VALUES (2, 4, 15, 10, 1);

INSERT INTO Logros VALUES (1, '+50k', 10000);
INSERT INTO Logros VALUES (2, '+500 aviones puntuales', 20000);
INSERT INTO Logros VALUES (3, 'Todas las terminales desbloqueadas', 10000);

INSERT INTO Jug_Log VALUES (1, 1, 'yes', 'yes');
INSERT INTO Jug_Log VALUES (2, 1, 'yes', 'no');
INSERT INTO Jug_Log VALUES (2, 1, 'no', 'no');
INSERT INTO Jug_Log VALUES (3, 2, 'yes', 'no');
	