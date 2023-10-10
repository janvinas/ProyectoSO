#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <mysql.h>
#include <stdio.h>

int main(int argc, char *charv[]){
	MYSQL *conn;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
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

	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char buff[512];
	char buff2[512];

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

	// bucle infinit per rebre peticions dels clients
	while(1){
		printf("Escuchando\n");
		//espera fins que un client realitzi una connexió
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Cliente conectado\n");
		while(1){
			ret=read(sock_conn,buff, sizeof(buff));
			//posa un valor 0 al final per acabar la string
			buff[ret]='\0';

			printf("Mensaje recibido!: %s\n", buff);

			char *token = strtok(buff, "/");
			int codigo = atoi(token);

			if(codigo == 0){
				close(sock_conn);
				printf("Cliente desconectado\n");
				break;
			}
			else if (codigo ==1){
				char nombre[40];
				strcpy(nombre, strtok(NULL, "/"));
				char password[40];
				strcpy(password, strtok(NULL, "/"));
				char query[500];
				sprintf(query, "SELECT Usuario FROM Jugador WHERE Usuario='%s' AND Password='%s'", nombre, password);
				int result = mysql_query(conn, query);
				if(result != 0){
					sprintf(buff2, "-1");
				}
				else{
					resultado = mysql_store_result (conn);
					row = mysql_fetch_row (resultado);
					if (row == NULL)
						sprintf(buff2,"0");
					else
						sprintf(buff2,"1");
				}
			}
			else if(codigo == 2){
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
					sprintf(buff2, "-1");
				}
				else{
					resultado = mysql_store_result (conn);
					row = mysql_fetch_row (resultado);
					if (row == NULL){
						char query2[500];
						sprintf(query2, "INSERT INTO Jugador (Usuario, Password, Mail, Genero) VALUES (\'%s\', \'%s\', \'%s\', \'%c\');", nombre, password, email, genero);
						int result = mysql_query(conn, query2);
						if(result != 0){
							sprintf(buff2, "-1");
						}else{
							sprintf(buff2, "1");
						}
					}else{
						sprintf(buff2,"0"); //Usuario o contraseña existentes
					}
				}
				
			}
			//TODO añadir mensaje de registro


			//imprimeix el buffer al socket i tanca'l
			//la resposta només s'envia si el codi del missatge no és 0
			write(sock_conn,buff2, strlen(buff2));
		}
	}
}