DROP DATABASE IF EXISTS T4_BBDDJuego;
CREATE DATABASE T4_BBDDJuego;
USE T4_BBDDJuego;
CREATE TABLE Jugador(
	ID INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
	Usuario TEXT NOT NULL,
	Password TEXT NOT NULL,
	Mail TEXT NOT NULL,
	Genero CHAR NOT NULL,
	XP INTEGER NOT NULL,
);

CREATE TABLE Partidas(
	ID INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
	Hfin DATETIME
);

CREATE TABLE Jug_Part(
	Jugador INTEGER NOT NULL,
	Partida INTEGER NOT NULL,
	Tiempo FLOAT,
	Posicion INTEGER NOT NULL,
	FOREIGN KEY (Jugador) REFERENCES Jugador(ID),
	FOREIGN KEY (Partida) REFERENCES Partidas(ID)
);


INSERT INTO Jugador VALUE(1,'PauSerrano','pauserrano','pau.serrano@gmail.com','M', 0);
INSERT INTO Jugador VALUE(2,'CarlosMunoz','carlosmunoz','carlos.munoz@gmail.com','M', 0);
INSERT INTO Jugador VALUE(3,'JanVinas','janvinas','jan.vinas@gmail.com','M', 0);

/*
INSERT INTO Partidas (HFin) VALUES ('2023-09-03 17:09:00');
INSERT INTO Partidas (HFin) VALUES ('2023-09-15 22:15:00');
INSERT INTO Partidas (HFin) VALUES ('2023-09-27 02:15:00');
INSERT INTO Partidas (HFin) VALUES ('2023-09-03 17:09:00');
INSERT INTO Partidas (HFin) VALUES ('2023-09-15 22:15:00');
INSERT INTO Partidas (HFin) VALUES ('2023-09-27 02:15:00')

INSERT INTO Jug_Part VALUES (1,1,20);
INSERT INTO Jug_Part VALUES (1,4,10);
INSERT INTO Jug_Part VALUES (1,6,5);
INSERT INTO Jug_Part VALUES (2,2,0);
INSERT INTO Jug_Part VALUES (3,3,40);
INSERT INTO Jug_Part VALUES (3,5,50);
*/
	
	