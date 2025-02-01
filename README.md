# MazeRunners
Maze Runners Elements
Introducción
Bienvenido a Maze Runners Elements, un juego de hasta 4 jugadores, donde cada jugador podra elegir una de las 4 facciones que representan a los 4 elementos. Ademas escogeran 3 fichas de entre 6 diferentes, cada una con un poder, velocidad y coldowns unicos.

Características del Juego
Cada jugador tendra un laberinto propio de igual dimension. Cada laberinto es generado aleatoriamente. Los jugadores deberan mover sus 3 fichas por el laberinto utilizando estrategias y sus habilidades para llegar a la salida. Esparcidas por el mapa habran 4 tipos distintos de trampas que se distribuiran de manera aleatoria.

Objetivo del Juego
El objetivo del juego es ser el primer jugador en llegar a la salida del laberinto con todas sus fichas.

Datos del juego
    Habilidades:
    1. Aumenta su velocidad
    2. Puede atravesar un obstaculo 
    3. Se hace inmune a las trampas
    4. Salta el turno del proximo jugador
    5. Disminuye 1 pto la velocidad del proximo jugador
    6. Aumenta 1 turno el cooldown del proximo jugador

    Tipos de trampas:
    1. Pierdes el turno
    2. Vuelves a la posicion inicial
    3. Se reinicia tu cooldown
    4. Tu velocidad es reducida a 1

Clases principales:
    1. GameManager.cs: Es donde estan implementados los metodos principales sobre el funcionamiento del juego
    2. Board.cs: Es donde se genera el laberinto.
    3. Player.cs: Es donde se le da estructura al jugador.
    4. Token.cs: Es donde se le da estructura a las fichas del jugador.

Controles:
Al ejecutar el juego debera seguir las instrucciones para crear el primer jugador. Luego sera el turno del proximo jugador. Si la cantidad de jugadores es menor que 4. Al finalizar la creacion del ultimo jugador, (Cuando le pide ingresar el nombre de otro jugador) se debera tocar ENTER para continuar. Una vez creados todos los jugadores, el juego comienza y los turnos seran en el orden en que fueron creados los jugadores.

Al iniciar el juego le pedira que seleccione la ficha que desea mover. Usted debera introducir el numero correspondiente a la ficha y tocar ENTER. Si desea Activar el poder (solo se puede si su cooldown esta en 0), debera tocar la tecla P antes de mover la ficha. Una vez la mueva no podra activar el poder hasta el proximo turno. Para mover su ficha utilice las flechas del teclado. Tenga en cuenta que tendra tantos movimientos como velocidad tenga la ficha seleccionada.