#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <mysql.h>
#include <stdio.h>
#include <pthread.h>

MYSQL *conn;
MYSQL_RES *resultado;
MYSQL_ROW row;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

void login(char *response){
	char nombre[40];
	strcpy(nombre, strtok(NULL, "/"));
	char password[40];
	strcpy(password, strtok(NULL, "/"));
	char query[500];
	sprintf(query, "SELECT Usuario FROM Jugador WHERE Usuario='%s' AND Password='%s'", nombre, password);
	int result = mysql_query(conn, query);
	if(result != 0){
		sprintf(response, "-1");
	}
	else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			sprintf(response,"0");
		else
			sprintf(response,"1");
	}
}

void signup(char *response){
	char nombre[50];
	strcpy(nombre, strtok(NULL, "/"));
	char password[50];
	strcpy(password, strtok(NULL, "/"));
	char email[90];
	strcpy(email, strtok(NULL, "/"));
	char genero = strtok(NULL, "/")[0];	//el género tiene un único carácter
	
	
	char query1[500];
	sprintf(query1, "SELECT Usuario FROM Jugador WHERE Usuario='%s'", nombre);
	int result = mysql_query(conn, query1);
	if(result != 0){
		sprintf(response, "-1");
	}
	else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL){
			char query2[500];
			sprintf(query2, "INSERT INTO Jugador (Usuario, Password, Mail, Genero) VALUES ('%s', '%s', '%s', '%c');", nombre, password, email, genero);
			pthread_mutex_lock(&mutex);
			result = mysql_query(conn, query2);
			pthread_mutex_unlock(&mutex);
			printf("%s\n",query2);
			if(result != 0){
				sprintf(response, "-1");
			}else{
				sprintf(response, "1");
			}
		}else{
			sprintf(response,"0"); //Usuario o contraseña existentes
		}
	}
}

void existeUsuario(char *response){
	char nombre[40];
	strcpy(nombre, strtok(NULL, "/"));
	char query[500];
	sprintf(query, "SELECT Usuario FROM Jugador WHERE Usuario='%s'", nombre);
	int result = mysql_query(conn, query);
	if(result != 0){
		sprintf(response, "-1");
	}
	else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			sprintf(response,"0");
		else
			sprintf(response,"1");
	}
}

void consultaBasicaConstrucciones(char *response){
	char construccion[50];
	strcpy(construccion, strtok(NULL, "/"));
	char query[500];
	sprintf(query, "SELECT Partidas.ID, Part_Const.X, Part_Const.Y FROM (Construcciones, Partidas, Part_Const) "
			"WHERE Construcciones.nombre = '%s' "
			"AND Construcciones.ID = Part_Const.ID_Const "
			"AND Partidas.ID = Part_Const.ID_Part;", construccion);
	int err = mysql_query(conn, query);
	if(err != 0){
		sprintf(response, "-1");
	}else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row(resultado);
		if(row == NULL){
			sprintf(response, "0");
		}else{
			sprintf(response, "%s/%s/%s", row[0], row[1], row[2]);
			row = mysql_fetch_row (resultado);
			while(row != NULL){
				sprintf(response, "%s/%s/%s/%s", response, row[0], row[1], row[2]);
				row = mysql_fetch_row (resultado);
			}
			printf("%s\n", response);
		}
	}
}

void consultaBasicaDinero(char *response){
	char nombre[80];
	char *token=strtok(NULL,"/");
	strcpy(nombre,token);
	char query1[500];
	sprintf(query1, "SELECT Jug_Part.Dinero FROM (Jugador, Partidas,Jug_Part) WHERE Jugador.Usuario = '%s' AND Jugador.ID = Jug_Part.Jugador AND Partidas.ID = Jug_Part.Partida;", nombre);
	int result = mysql_query(conn, query1);
	if(result != 0){
		sprintf(response, "-1");
	}
	else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			sprintf(response,"-2");
		else{
			int dtotal=0;
			while(row!=NULL){
				dtotal += atoi(row[0]);
				row = mysql_fetch_row (resultado);
			}
			sprintf(response,"%d",dtotal);
		}
	}
}

void consultaBasicaLogros(char *response){
	char query[500];
	sprintf(query, "SELECT Jugador.Usuario, Logros.descripcion FROM (Jugador, Logros, Jug_Log) WHERE Jug_Log.logro_obtenido = 'yes' AND Jug_Log.recompensa_obtenida = 'no' AND Jugador.ID = Jug_Log.ID_Jugadores AND Logros.ID = Jug_Log.ID_Logro;");
	int err = mysql_query(conn, query);
	if(err != 0){
		sprintf(response, "-1");
	}else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row(resultado);
		if(row == NULL){
			sprintf(response, "0");
		}else{
			sprintf(response, "%s/%s", row[0], row[1]);
			row = mysql_fetch_row (resultado);
			while(row != NULL){
				sprintf(response, "%s/%s/%s", response, row[0], row[1]);
				row = mysql_fetch_row (resultado);
			}
			printf("%s\n", response);
		}
	}
}


// función que se ejecutará cada vez que un cliente se conecte y se cree un socket.
// la función termina cuando el cliente se desconecta.
void *atenderCliente(void *socket){
	int sock_conn = *((int*) socket);

	char buff[512];
	char buff2[512];

	while(1){
		int ret=read(sock_conn,buff, sizeof(buff));
		//posa un valor 0 al final per acabar la string
		buff[ret]='\0';

		printf("Mensaje recibido!: %s\n", buff);

		char *token = strtok(buff, "/");
		int codigo = atoi(token);

		if(codigo == 0){
			close(sock_conn);
			printf("Cliente desconectado\n");
			break;
		}else if (codigo ==1){
			login(buff2);
		}else if(codigo == 2){
			signup(buff2);
		}else if(codigo == 3){
			existeUsuario(buff2);
		}else if(codigo == 4){
			consultaBasicaConstrucciones(buff2);
		}else if(codigo==5){
			consultaBasicaDinero(buff2);
		}else if(codigo==6){
			consultaBasicaLogros(buff2);
		}

		//imprimeix el buffer al socket i tanca'l
		//la resposta només s'envia si el codi del missatge no és 0
		write(sock_conn,buff2, strlen(buff2));
		printf("Respuesta enviada!: %s\n", buff2);
	}
}

int main(int argc, char *charv[]){
	conn = mysql_init(NULL);
	if(conn==NULL){
		printf("Error creant connexió SQL: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(-1);
	}
	conn = mysql_real_connect(conn, "localhost", "root", "mysql", "AirportSIM", 0, NULL, 0);
	if(conn==NULL){
		printf("Error creant connexió SQL: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(-1);
	}

	int sock_listen;
	struct sockaddr_in serv_adr;
	
	if((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0){
		printf("Error creant socket");
		exit(-1);
	}

	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9050);

	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0){
		printf ("Error al bind");
		exit(-1);
	}
	//La cola de peticiones pendientes no podr? ser superior a 4 --> no sería 2 ???
	if (listen(sock_listen, 2) < 0){
		printf("Error en el Listen");
		exit(-1);
	}

	int sockets[100];
	int i = 0;
	while(1){
		printf("Escuchando\n");
		int sock_conn = accept(sock_listen, NULL, NULL);
		printf("Cliente conectado\n");
		sockets[i] = sock_conn;
		pthread_t t;	//no necessitem aquest valor, no el guardem enlloc
		pthread_create(&t, NULL, atenderCliente, &sockets[i]);
		i++;
	}
}
