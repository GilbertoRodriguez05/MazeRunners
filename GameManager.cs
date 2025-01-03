using System.Collections.Concurrent;
using System.IO.Compression;
using System.Net.WebSockets;

class GameManager
{
    List<Player> players = new List<Player> ();
    public void StartGame()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Clear();
        Console.WriteLine("------------------------Maze Runners------------------------");
        Thread.Sleep(3000);
        Console.Clear();
        Console.ResetColor();

        List<Factions> factions = new List<Factions>{Factions.Fire, Factions.Water, Factions.Wind, Factions.Earth};
        List<string> factionsName = new List<string> { ". Fuego", ". Agua", ". Aire", ". Tierra" };
        Turn[] turnos = (Turn[])Enum.GetValues(typeof(Turn));

        int jugadores = 0;
        while(jugadores < 4)
        {
            System.Console.WriteLine("Escriba el nombre del jugador");
            string name = System.Console.ReadLine()?? string.Empty;
            if(string.IsNullOrEmpty(name))
            {
                break;
            }
            else
            {
                int factionNum;
                while (true)
                {
                    System.Console.WriteLine("Seleccione el numero de la faccion deseada: ");
                    for (int i = 0; i < factionsName.Count; i++)
                    {
                        System.Console.WriteLine(i + factionsName[i]);
                    }
                    factionNum = Convert.ToInt32(System.Console.ReadLine());
                    if(factionNum < factions.Count && factionNum >= 0)
                    {
                        break;
                    }
                }
                players.Add(new Player(name, turnos[players.Count], factions[factionNum], new Board(15)));
                
                factionsName.RemoveAt(factionNum);
                factions.RemoveAt(factionNum);
                Console.Clear();
                System.Console.WriteLine("Seleccione una ficha");
                Console.BackgroundColor = ConsoleColor.Black;
                
                if (players[jugadores].factions == Factions.Fire)
                {
                    int fichas = 0;
                    List<int> numFichas = new List<int>();

                    while (fichas < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < TokenBank.Fire.Count; i++)
                        {
                            if(!numFichas.Contains(i))
                            {
                                System.Console.WriteLine(i + ". " + TokenBank.Fire[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        int n = int.Parse(Console.ReadLine()??string.Empty);
                        if (n < 0 || n > TokenBank.Fire.Count - 1)
                        {
                            continue;
                        }
                        if (numFichas.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        numFichas.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Fire[n]);
                        Console.Clear();
                        if (fichas == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        fichas ++;
                    }
                }
                else if (players[jugadores].factions == Factions.Water)
                {
                    int fichas = 0;
                    List<int> numFichas = new List<int>();

                    while (fichas < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 0; i < TokenBank.Water.Count; i++)
                        {
                            if(!numFichas.Contains(i))
                            {
                                System.Console.WriteLine(i + ". " + TokenBank.Water[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        int n = int.Parse(Console.ReadLine()??string.Empty);
                        if (n < 0 || n > TokenBank.Water.Count - 1)
                        {
                            continue;
                        }
                        if (numFichas.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        numFichas.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Water[n]);
                        Console.Clear();
                        if (fichas == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        fichas ++;
                    }
                }
                else if (players[jugadores].factions == Factions.Wind)
                {
                    int fichas = 0;
                    List<int> numFichas = new List<int>();

                    while (fichas < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        for (int i = 0; i < TokenBank.Wind.Count; i++)
                        {
                            if(!numFichas.Contains(i))
                            {
                                System.Console.WriteLine(i + ". " + TokenBank.Wind[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        int n = int.Parse(Console.ReadLine()??string.Empty);
                        if (n < 0 || n > TokenBank.Wind.Count - 1)
                        {
                            continue;
                        }
                        if (numFichas.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        numFichas.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Wind[n]);
                        Console.Clear();
                        if (fichas == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        fichas ++;
                    }
                }
                else if (players[jugadores].factions == Factions.Earth)
                {
                    int fichas = 0;
                    List<int> numFichas = new List<int>();

                    while (fichas < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < TokenBank.Earth.Count; i++)
                        {
                            if(!numFichas.Contains(i))
                            {
                                System.Console.WriteLine(i + ". "+TokenBank.Earth[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        int n = int.Parse(Console.ReadLine()??string.Empty);
                        if (n < 0 || n > TokenBank.Earth.Count - 1)
                        {
                            continue;
                        }
                        if (numFichas.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        numFichas.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Earth[n]);
                        Console.Clear();
                        if (fichas == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        fichas ++;
                    }
                }
            }
            players [0].TurnActive = true;
            jugadores++;
        }
    }
    public void PassTurn(int index)
    {
        players [index].TurnActive = false;
        if (index + 1 >= players.Count)
        {
            players [0].TurnActive = true;
        }
        else
        {
            players [index + 1].TurnActive = true;
        }
    }
    public void Play()
    {
        while (true)
        {
            DecreaseCooldown(players);
            bool SlowDown = false;
            bool IncreaseCooldown = false;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].TurnActive == true && !players[i].PassTurn)
                {
                    Console.Clear();
                    PrintToken(players, i);
                    if (IncreaseCooldown)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            players[i].Selected[j].CooldownActive ++;
                        }
                    }
                    IncreaseCooldown = false;
                    int n;
                    while (true)
                    {
                        System.Console.WriteLine(players[i].Name + " seleccione la ficha que desea mover");
                        for (int j = 0; j < players[i].Selected.Count; j++)
                        {
                            TokenColor(players[i]);
                            System.Console.WriteLine(j + " " + players[i].Selected [j].ToString());
                            Console.ResetColor();
                        }
                        n = int.Parse(Console.ReadLine()??string.Empty);
                        if (n >= 0 && n < players[i].Selected.Count)
                        {
                            break;
                        }
                    }
                    Token FichaActual = players[i].Selected[n];
                    int Speed = FichaActual.Speed;
                    if (SlowDown)
                    {
                        FichaActual.Speed -= 1;
                    }
                    SlowDown = false;
                    
                    int vel = 1;
                    while (vel <= FichaActual.Speed)
                    {
                        if (WinCondition(players[i]))
                        {
                            System.Console.WriteLine($"Ha ganado el jugador {players[i].Name}");
                            return;
                        }
                        ConsoleKeyInfo tecla = Console.ReadKey(true);
                        Console.Clear();
                        if(FichaActual.PosCol == players[i].board.columnas-2 && FichaActual.PosFil == players[i].board.filas-2)
                        {
                            System.Console.WriteLine("Esta ficha ya esta en la posicion final");
                            Thread.Sleep(3000);
                            break;
                        }

                        if (tecla.Key == ConsoleKey.P && FichaActual.CooldownActive == 0 && vel == 1)
                        {
                            System.Console.WriteLine("Activaste el poder");
                            Thread.Sleep(1000);
                            FichaActual.CooldownActive = FichaActual.Cooldown;
                            if (FichaActual.powers == PowersBank.Powers.SpeedPower)
                            {
                                Console.Clear();
                                PowersBank.SpeedPower(FichaActual);
                            }
                            else if (FichaActual.powers == PowersBank.Powers.GetThroughObstacles)
                            {
                                PrintToken(players, i);
                                PowersBank.GetThroughObstacles(FichaActual, players[i]);
                                PassTurn(i);
                                break;
                            }
                            else if(FichaActual.powers == PowersBank.Powers.InmuneTraps)
                            {
                                Console.Clear();
                                PowersBank.InmuneTraps(FichaActual);
                            }
                            else if (FichaActual.powers == PowersBank.Powers.SkipTurn)
                            {
                                if (i + 1 < players.Count)
                                {
                                    players[i+1].PassTurn = true;
                                }
                                else
                                {
                                    players[0].PassTurn = true;
                                }
                            }
                            else if (FichaActual.powers == PowersBank.Powers.SlowDown)
                            {
                                Console.Clear();
                                PowersBank.SlowDown(FichaActual);
                                SlowDown = true;
                            }
                            else if (FichaActual.powers == PowersBank.Powers.IncreaseCooldown)
                            {
                                Console.Clear();
                                PowersBank.IncreaseCooldown(FichaActual);
                                IncreaseCooldown = true;
                            }
                        }
                        
                        if (tecla.Key == ConsoleKey.UpArrow && players[i].board.matriz[FichaActual.PosFil - 1, FichaActual.PosCol])
                        {
                            FichaActual.PosFil += -1;
                            vel ++;
                        }
                        else if (tecla.Key == ConsoleKey.DownArrow && players[i].board.matriz[FichaActual.PosFil + 1, FichaActual.PosCol])
                        {
                           FichaActual.PosFil += 1;
                           vel ++;
                        }
                        else if (tecla.Key == ConsoleKey.RightArrow && players[i].board.matriz[FichaActual.PosFil, FichaActual.PosCol + 1])
                        {
                            FichaActual.PosCol += 1;
                            vel ++;
                        }
                        else if (tecla.Key == ConsoleKey.LeftArrow && FichaActual.PosFil == 1 && FichaActual.PosCol == 0)
                        {
                            PrintToken(players, i);
                            continue;
                        }
                        else if (tecla.Key == ConsoleKey.LeftArrow && players[i].board.matriz[FichaActual.PosFil, FichaActual.PosCol - 1])
                        {
                           FichaActual.PosCol += -1;
                           vel ++;
                        }
                        if (players[i].board.board[FichaActual.PosFil, FichaActual.PosCol] is Traps traps && traps.IsActive)
                        {
                            if (traps.trapstypes == TrapsTypes.MissTurn)
                            {
                                traps.IsActive = false;
                                if (FichaActual.powers == PowersBank.Powers.InmuneTraps && FichaActual.PowerActive)
                                {
                                    System.Console.WriteLine("has caido en una trampa pero te has protegido");
                                }
                                else
                                {
                                    System.Console.WriteLine("Has Caido en una trampa y has perdido el turno");
                                    Thread.Sleep(3000);
                                    break;
                                }
                            }
                            else if (traps.trapstypes == TrapsTypes.BackToStart)
                            {
                                traps.IsActive = false;
                                if (FichaActual.powers == PowersBank.Powers.InmuneTraps && FichaActual.PowerActive)
                                {
                                    System.Console.WriteLine("Has caido en una trampa pero te has protegido");
                                }
                                else
                                {
                                    FichaActual.PosFil = 1;
                                    FichaActual.PosCol = 1;
                                    System.Console.WriteLine("Has caido en una trampa y has vuelto al inicio");
                                    Thread.Sleep(3000);
                                    break;
                                }
                            }
                            else if (traps.trapstypes == TrapsTypes.ResetCooldown)
                            {
                                traps.IsActive = false;
                                if (FichaActual.powers == PowersBank.Powers.InmuneTraps && FichaActual.PowerActive)
                                {
                                    System.Console.WriteLine("Has caido en una trampa pero te has protegido");
                                }
                                else
                                {
                                    FichaActual.CooldownActive = FichaActual.Cooldown;
                                    System.Console.WriteLine("Has caido en una trampa y tu cooldown ha sido reiniciado");
                                    Thread.Sleep(3000);
                                }
                            }
                            else if (traps.trapstypes == TrapsTypes.GetSlow)
                            {
                                traps.IsActive = false;
                                if (FichaActual.powers == PowersBank.Powers.InmuneTraps && FichaActual.PowerActive)
                                {
                                    System.Console.WriteLine("Has caido en una trampa pero te has protegido");
                                }
                                else
                                {
                                    FichaActual.Speed = 1;
                                    System.Console.WriteLine("Has caido en una trampa y tu velicidad se ha reducido a 1");
                                    Thread.Sleep(3000);
                                }
                            }
                        }
                        PrintToken(players, i);
                    }
                    if (FichaActual.powers == PowersBank.Powers.SpeedPower && FichaActual.PowerActive)
                    {
                        FichaActual.Speed -= 3;
                    }
                    
                    FichaActual.Speed = Speed;
                    FichaActual.PowerActive = false;
                }
                PassTurn(i);
                players[i].PassTurn = false;
            }
        }
    }
    public void DecreaseCooldown(List<Player> players)
    {
       for (int i = 0; i < players.Count; i++)
       {
            for (int j = 0; j < 3; j++)
            {
                if (players[i].Selected[j].CooldownActive > 0)
                {
                    players[i].Selected[j].CooldownActive -= 1;
                }
            }
       }
    }
    public bool WinCondition(Player player)
    {
        bool Win = false;
        for (int i = 0; i < 3; i++)
        {
            if (player.Selected[i].PosFil == player.board.filas - 2 && player.Selected[i].PosCol == player.board.columnas - 2)
            {
                Win = true;
            }
            else
            {
                return false;
            }
        }
        return Win;
    }
    public void PrintToken(List<Player> players, int i)
    {
        for (int a = 0; a < players[i].board.filas; a++)
        {
            for (int b = 0; b < players[i].board.columnas; b++)
            {
                if (players[i].Selected[0].PosFil == a && players[i].Selected[1].PosFil == a && players[i].Selected[2].PosFil == a && players[i].Selected[0].PosCol == b && players[i].Selected[1].PosCol == b && players[i].Selected[2].PosCol == b)
                {
                    System.Console.Write(" 3");
                }
                else if (players[i].Selected[0].PosFil == a && players [i].Selected[1].PosFil == a && players[i].Selected[0].PosCol == b && players[i].Selected[1].PosCol == b)
                {
                    System.Console.Write(" 2");
                }
                else if (players[i].Selected[0].PosFil == a && players [i].Selected[2].PosFil == a && players[i].Selected[0].PosCol == b && players[i].Selected[2].PosCol == b)
                {
                    System.Console.Write(" 2");
                }
                else if (players[i].Selected[1].PosFil == a && players [i].Selected[2].PosFil == a && players[i].Selected[1].PosCol == b && players[i].Selected[2].PosCol == b)
                {
                    System.Console.Write(" 2");
                } 
                else if (players[i].Selected[0].PosFil == a && players[i].Selected[0].PosCol == b)
                {
                    System.Console.Write(" a");
                }
                else if (players[i].Selected[1].PosFil == a && players[i].Selected[1].PosCol == b)
                {
                    System.Console.Write(" b");
                }
                else if (players[i].Selected[2].PosFil == a && players[i].Selected[2].PosCol == b)
                {
                    System.Console.Write(" c");
                }
                else if (players[i].board.matriz [a, b])
                {
                    System.Console.Write("  ");
                }
                else
                {
                    System.Console.Write("██");
                }
            }
            System.Console.WriteLine();
        }
    }
    public void TokenColor(Player player)
    {
        if (player.factions == Factions.Fire)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else if (player.factions == Factions.Earth)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (player.factions == Factions.Water)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        else if (player.factions == Factions.Wind)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}