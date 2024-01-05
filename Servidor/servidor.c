#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <mysql.h>
#include <stdio.h>
#include <pthread.h>

#define DEBUG 0

typedef struct{
	char nombre [50];
	int socket;
} Conectado;
typedef struct{
	Conectado conectados[100];
	int num;
} ListaConectados;

typedef struct{
	char nombre[80];
	char aceptado;
	double x;
	double y;
	double rot;
	double tiempoFinal;
	int coche;
	int posicion;
}Jugador;
typedef struct{
	Jugador jugadores[20];
	int numJugadores;
}Partida;
typedef struct{
	Partida partidas[20];
	int numPartidas;
}ListaPartidas;

ListaPartidas listaPartidas;

int sockets[100];
int numSockets = 0;

MYSQL *conn;
MYSQL_RES *resultado;
MYSQL_ROW row;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
ListaConectados listaConectados;


/*********************************************
Funciones que gestionan la lista de conectados
**********************************************/

int addConectado (ListaConectados *lista, char nombre[50], int socket) {
	if (lista -> num == 100){
		return -1;
	}
	else {
		strcpy(lista -> conectados[lista -> num].nombre, nombre);
		lista -> conectados[lista->num].socket = socket;
		lista -> num++;
		return 0;
	}
}

int DameNombre (ListaConectados *lista, int socket, char nombre[50]) {
	int i=0;
	int encontrado = 0;
	while ((i < (lista -> num)) && encontrado == 0){
		if (lista -> conectados[i].socket == socket)
			encontrado = 1;
		if (encontrado == 0)
			i++;
	}
	if (encontrado  == 1){
		strcpy(nombre, lista -> conectados[i].nombre);
		return 0;
	}
	else
		return -1;
}

int DamePosicion (ListaConectados *lista, char nombre[50]) {
	int i=0;
	int encontrado = 0;
	while ((i < (lista -> num)) && encontrado == 0){
		if (strcmp(lista -> conectados[i].nombre, nombre) == 0)
			encontrado = 1;
		if (encontrado == 0)
			i++;
	}
	if (encontrado  == 1)
		return i;
	else
		return -1;
}
	
int eliminarConectado (ListaConectados *lista, char nombre[50])
{
	int pos = DamePosicion (lista, nombre);
	if (pos == -1)
		return -1;
	else {

		for (int i = pos; i < lista -> num-1; i++)
		{
			strcpy(lista -> conectados[i].nombre, lista -> conectados[i+1].nombre);
			lista -> conectados[i].socket = lista -> conectados[i+1].socket;
		}
		lista->num = lista->num-1;
		return 0;
	
	}
}

void DameConectados(ListaConectados * lista, char conectados[300]) {
	//Pone en conectados los nombres de todos los conectados separados por /
	// "7/n/Juan/Maria/Pedro"
	sprintf(conectados, "7/%d", lista -> num);
	for (int i=0; i < lista -> num; i++)
		sprintf (conectados, "%s/%s", conectados, lista->conectados[i].nombre);
}

/**
 * Envía una notifiación a todos los usuarios con la nueva lista de conectados.
 * Código de respuesta: 7
*/
void enviarConectados(){
	char stringConectados[300];
	DameConectados(&listaConectados, stringConectados);
	sprintf(stringConectados, "%s\n", stringConectados);
	for(int i = 0; i < listaConectados.num; i++){
		write(listaConectados.conectados[i].socket, stringConectados, strlen(stringConectados));
	}
	printf("Notificación enviada!: %s\n", stringConectados);
}

/*******************************
Funciones de gestión de usuarios
*******************************/

void login(char *response, int socket, ListaConectados *lista){
	char nombre[50];
	strcpy(nombre, strtok(NULL, "/"));
	char password[50];
	strcpy(password, strtok(NULL, "/"));
	char query[500];
	sprintf(query, "SELECT Usuario FROM Jugador WHERE Usuario='%s' AND Password='%s'", nombre, password);
	int result = mysql_query(conn, query);
	if(result != 0){
		sprintf(response, "1/-1");
	}
	else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			sprintf(response,"1/0");
		else
		{
			sprintf(response,"1/1");
			addConectado(lista, nombre, socket);
			enviarConectados();	//envía una notificación a todos los usuarios con la nueva lista de conectados
		}	
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
		sprintf(response, "2/-1");
	}
	else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL){
			char query2[500];
			sprintf(query2, "INSERT INTO Jugador (Usuario, Password, Mail, Genero) VALUES ('%s', '%s', '%s', '%c');", nombre, password, email, genero);
			result = mysql_query(conn, query2);
			printf("%s\n",query2);
			if(result != 0){
				sprintf(response, "2/-1");
			}else{
				sprintf(response, "2/1");
			}
		}else{
			sprintf(response,"2/0"); //Usuario o contraseña existentes
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
		sprintf(response, "3/-1");
	}
	else{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			sprintf(response,"3/0");
		else
			sprintf(response,"3/1");
	}
}



void invitacionJugadores(char *response, int socketOrigen) {
	int numInvitados;
	char nombre[80];
	char nombreInvitador[80];
	numInvitados = atoi(strtok(NULL, "/"));

	char invitacion[300];
	DameNombre(&listaConectados, socketOrigen, nombreInvitador);
	
	int idPartida = listaPartidas.numPartidas;
	strcpy(listaPartidas.partidas[idPartida].jugadores[0].nombre, nombreInvitador);
	listaPartidas.partidas[idPartida].numJugadores = 1;
	listaPartidas.numPartidas++;

	sprintf(response, "8/%d", idPartida); // se envía de vuelta el ID de partida
	
	int i = 0;
	while (i<numInvitados){
		char *token = strtok(NULL,"/");
		strcpy(nombre,token);
		int n = DamePosicion(&listaConectados, nombre);
		if (n != -1)
		{
			//añadir jugador a la lista de partidas
			int numJugador = listaPartidas.partidas[idPartida].numJugadores;
			strcpy(listaPartidas.partidas[idPartida].jugadores[numJugador].nombre, listaConectados.conectados[n].nombre);
			listaPartidas.partidas[idPartida].jugadores[numJugador].x = 0;
			listaPartidas.partidas[idPartida].jugadores[numJugador].y = 0;
			listaPartidas.partidas[idPartida].jugadores[numJugador].rot = 180;
			listaPartidas.partidas[idPartida].jugadores[numJugador].aceptado = 0;
			listaPartidas.partidas[idPartida].jugadores[numJugador].tiempoFinal = -1;
			listaPartidas.partidas[idPartida].jugadores[numJugador].coche = 0;
			listaPartidas.partidas[idPartida].jugadores[numJugador].posicion = 0;
			listaPartidas.partidas[idPartida].numJugadores++;

			//enviar notificación al jugador
			sprintf(invitacion, "9/%d/%s\n", idPartida, nombreInvitador);
			write(listaConectados.conectados[n].socket, invitacion, strlen(invitacion));
			printf("Notificación enviada a %s\n", nombre);
		}
		i++;
	}
}

void aceptarInvitacion(char *response, int socketOrigen){ //10/idPartida/aceptado(1),rechazado(0)
	int aceptado;
	int idPartida;
	char personaAceptado[80];
	char mensaje[300];
	idPartida = atoi(strtok(NULL, "/"));
	aceptado = atoi(strtok(NULL, "/"));

	sprintf(response, "10/1");
	
	DameNombre(&listaConectados, socketOrigen, personaAceptado);
	for(int i=0; i<listaPartidas.partidas[idPartida].numJugadores; i++){
		char jugadorActual[50];
		strcpy(jugadorActual, listaPartidas.partidas[idPartida].jugadores[i].nombre);

		if(strcmp(personaAceptado, jugadorActual) == 0){
			listaPartidas.partidas[idPartida].jugadores[i].aceptado = aceptado;
		}
		else if(aceptado){
			sprintf(mensaje, "11/%d/%s\n",idPartida, personaAceptado);
			int n = DamePosicion(&listaConectados, jugadorActual);
			if (n != -1)
			{
				write(listaConectados.conectados[n].socket, mensaje, strlen(mensaje));
				printf("Notificación 'aceptar' enviada a %s\n", jugadorActual);
			}
		}
		
	}
}
void enviarFrase(char *response, int socketOrigen){
	char *token;
	token = strtok(NULL, "/");
	if(token == NULL){
		sprintf(response, "12/0");
		return;
	}
	int idPartida = atoi(token);

	token = strtok(NULL, "/");
	if(token == NULL){
		sprintf(response, "12/0");
		return;
	}
	char nombreEnviador[80];
	strcpy(nombreEnviador, token);

	token = strtok(NULL, "/");
	if(token == NULL){
		sprintf(response, "12/0");
		return;
	}
	char frase[200];
	strcpy(frase, token);

	//ningún error ha ocurrido, imprimimos 12/1
	sprintf(response,"12/1");

	char notificacion[300];	
	sprintf(notificacion, "13/%s/%s\n", nombreEnviador, frase);

	for(int i=0; i<listaPartidas.partidas[idPartida].numJugadores; i++){
		char jugadorActual[50];
		strcpy(jugadorActual, listaPartidas.partidas[idPartida].jugadores[i].nombre);
		int n = DamePosicion(&listaConectados, jugadorActual);

		if (n != -1)
		{
			write(listaConectados.conectados[n].socket, notificacion, strlen(notificacion));
			printf("Frase enviada a %s\n", jugadorActual);
		}
	}
}


/**
 * Se ejecuta cuando un cliente se ha desconectado. Elimina la entrada de la lista de conectados
 * si tenía la sesión iniciada.
 * 
 * @param forced Poner a true si la desconexión ha sido forzosa (se imprime un mensaje en la consola).
*/
void desconectarCliente(int sock_conn, char forced){
	close(sock_conn);

	char nombre[50];
	int err = DameNombre(&listaConectados, sock_conn, nombre);
	if(err == 0){
		//si el cliente que se ha desconectado tenía sesión iniciada, ciérrala.
		eliminarConectado(&listaConectados, nombre);
		enviarConectados();	//envía una notificación a todos los usuarios con la nueva lista de conectados
		printf("Cliente %s desconectado", nombre);
	}else{
		printf("Cliente sin sesión iniciada desconectado");
	}

	if(forced){
		printf(" forzosamente.\n");
	}else{
		printf(".\n");
	}
}

void actualizarPosicion(char *response, int sock_conn){
	int idPartida = atoi(strtok(NULL, "/"));
	char nombreUsuario[50];
	strcpy(nombreUsuario, strtok(NULL, "/"));
	double x = atof(strtok(NULL, "/"));
	double y = atof(strtok(NULL, "/"));
	double rot = atof(strtok(NULL, "/"));
	int coche = atoi(strtok(NULL, "/"));

	sprintf(response, "14");
	if(idPartida == -1) return;

	for(int i = 0; i < listaPartidas.partidas[idPartida].numJugadores; i++){
		if(strcmp(listaPartidas.partidas[idPartida].jugadores[i].nombre, nombreUsuario) == 0){
			//jugador que ha mandado su posición. La actualizamos
			listaPartidas.partidas[idPartida].jugadores[i].x = x;
			listaPartidas.partidas[idPartida].jugadores[i].y = y;
			listaPartidas.partidas[idPartida].jugadores[i].rot = rot;
			listaPartidas.partidas[idPartida].jugadores[i].coche = coche;
		}else{
			//para los demás jugadores, añadimos su nombre y posicion a la respuesta
			sprintf(response, "%s/%s/%f/%f/%f/%d", response, 
				listaPartidas.partidas[idPartida].jugadores[i].nombre,
				listaPartidas.partidas[idPartida].jugadores[i].x,
				listaPartidas.partidas[idPartida].jugadores[i].y,
				listaPartidas.partidas[idPartida].jugadores[i].rot,
				listaPartidas.partidas[idPartida].jugadores[i].coche);
		}
	}
}

void iniciarPartida(char *response, int sock_conn){
	char *token;

	token = strtok(NULL, "/");
	if(token == NULL){
		sprintf(response, "15/0");
		return;
	}
	int idPartida = atoi(token);

	token = strtok(NULL, "/");
	if(token == NULL){
		sprintf(response, "15/0");
		return;
	}
	char mapa[50];
	strcpy(mapa, token);

	sprintf(response, "15/1");

	char notificacion[60];	
	sprintf(notificacion, "16/%s\n", mapa);

	for(int i=0; i<listaPartidas.partidas[idPartida].numJugadores; i++){
		char jugadorActual[50];
		strcpy(jugadorActual, listaPartidas.partidas[idPartida].jugadores[i].nombre);
		int n = DamePosicion(&listaConectados, jugadorActual);

		if (n != -1)
		{
			write(listaConectados.conectados[n].socket, notificacion, strlen(notificacion));
			printf("Inicio de partida enviado a %s\n", jugadorActual);
		}
	}
}

void acabarCarrera(char *response, int sock_conn){
	int idPartida = atoi(strtok(NULL, "/"));
	char nombreUsuario[50];
	strcpy(nombreUsuario, strtok(NULL, "/"));
	float tiempo = atof(strtok(NULL, "/"));
	float mejorTiempo = atof(strtok(NULL, "/"));
	
	sprintf(response, "17/1");

	//busca el jugador y añade su tiempo final
	for(int i=0; i<listaPartidas.partidas[idPartida].numJugadores; i++){
		if(strcmp(listaPartidas.partidas[idPartida].jugadores[i].nombre, nombreUsuario) == 0){
			listaPartidas.partidas[idPartida].jugadores[i].tiempoFinal = tiempo;
		} 
	}

	char notificacion[50];
	sprintf(notificacion, "18/%s/%f/%f", nombreUsuario, tiempo, mejorTiempo);

	//envía una notificación a todos los jugadores
	for(int i=0; i<listaPartidas.partidas[idPartida].numJugadores; i++){
		char jugadorActual[50];
		strcpy(jugadorActual, listaPartidas.partidas[idPartida].jugadores[i].nombre);
		int n = DamePosicion(&listaConectados, jugadorActual);

		if (n != -1) write(listaConectados.conectados[n].socket, notificacion, strlen(notificacion));
	}

	//comprueba si todos los jugadores han acabado
	char partidaTerminada = 1;
	for(int i = 0; i < listaPartidas.partidas[idPartida].numJugadores; i++){
		if(listaPartidas.partidas[idPartida].jugadores[i].tiempoFinal == -1) partidaTerminada = 0;
	}
	if(!partidaTerminada) return;

	//si la partida está terminada, guárdala en la base de datos
	acabarPartida(idPartida);

}

void ordenarJugadores(){
	//TODO ordenar jugadores
}

void acabarPartida(int idPartida){
	char query[500];
	sprintf(query, "INSERT INTO Partidas (HFin) VALUES (NOW());");
	mysql_query(conn, query);

	sprintf(query, "SELECT LAST_INSERT_ID();");
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	int idPartidaBD = atoi(row[0]);

	ordenarJugadores();

	for(int i = 0; i < listaPartidas.partidas[idPartida].numJugadores; i++){
		Jugador jugador = listaPartidas.partidas[idPartida].jugadores[i];
		if(jugador.tiempoFinal != -1){
			sprintf(query, "INSERT INTO Jug_Part (Jugador, Partida, Tiempo, Posicion) VALUES ( (SELECT ID FROM Jugador WHERE Usuario=\"%s\"), %d, %f, %d);",
			jugador.nombre, idPartidaBD, jugador.tiempoFinal, jugador.posicion);
		}
	}
}



/**
* función que se ejecutará cada vez que un cliente se conecte y se cree un socket.
* la función termina cuando el cliente se desconecta.
*/
void *atenderCliente(void *socket){
	int sock_conn = *((int*) socket);

	char buff[512]; //petición
	char buff2[512]; //respuesta

	while(1){
		int ret=read(sock_conn,buff, sizeof(buff));
		//posa un valor 0 al final per acabar la string
		buff[ret]='\0';

		if(ret == 0){
			//0 bytes significa que el cliente se ha desconectado (equivalente a que mande un código 0/ )
			desconectarCliente(sock_conn, 1);
			break;
		}else if(ret < 0){
			//ha ocurrido un error leyendo el socket. Imprime el error por consola:
			printf("Ha ocurrido un error leyendo el socket");
		}

		if(DEBUG) printf("Mensaje recibido!: %s\n", buff);

		char *token = strtok(buff, "/");
		int codigo = atoi(token);

		if(codigo == 0){
			desconectarCliente(sock_conn, 0);
			break;
		}else if (codigo ==1){
			login(buff2, sock_conn, &listaConectados);
		}else if(codigo == 2){
			signup(buff2);
		}else if(codigo == 3){
			existeUsuario(buff2);
		}else if(codigo==7){
			enviarConectados();
		}else if(codigo==8) {
			invitacionJugadores(buff2, sock_conn);
		}else if(codigo==10){
			aceptarInvitacion(buff2,sock_conn);
		}else if(codigo==12){
			enviarFrase(buff2,sock_conn);
		}else if(codigo==14){
			actualizarPosicion(buff2, sock_conn);
		}else if(codigo==15){
			iniciarPartida(buff2, sock_conn);
		}else if(codigo=17){
			acabarCarrera(buff2, sock_conn);
		}else{
			continue;
		}
		
		//imprimeix el buffer al socket i tanca'l
		//la resposta només s'envia si el codi del missatge no és 0
		sprintf(buff2, "%s\n", buff2);	//afegeix un salt de línia per indicar final del missatge
		write(sock_conn,buff2, strlen(buff2));
		//printf("Respuesta enviada!: %s", buff2);	//no cal fer un altre salt de línia, buff2 sempre acaba en un
	}
}

int main(int argc, char *charv[]){
	listaConectados.num=0;
	
	conn = mysql_init(NULL);
	if(conn==NULL){
		printf("Error creant connexió SQL: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(-1);
	}
	conn = mysql_real_connect(conn, "localhost", "root", "mysql", "T4_BBDDJuego", 0, NULL, 0);
	if(conn==NULL){
		printf("Error creant connexió SQL: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(-1);
	}

	int sock_listen;
	struct sockaddr_in serv_adr;
	
	if((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0){
		printf("Error creant socket\n");
		exit(-1);
	}

	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9050);

	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0){
		printf ("Error al bind\n");
		exit(-1);
	}
	//La cola de peticiones pendientes no podr? ser superior a 4 --> no sería 2 ???
	if (listen(sock_listen, 2) < 0){
		printf("Error en el Listen\n");
		exit(-1);
	}

	while(1){
		printf("Escuchando\n");
		int sock_conn = accept(sock_listen, NULL, NULL);
		printf("Cliente conectado\n");
		sockets[numSockets] = sock_conn;
		pthread_t t;	//no necessitem aquest valor, no el guardem enlloc
		pthread_create(&t, NULL, atenderCliente, &sockets[numSockets]);
		numSockets++;
	}
}
