using System.IO.Compression;

class GameManager
{
    Board map = new Board (31);
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
                System.Console.WriteLine("Seleccione el numero de la faccion deseada: ");
                for (int i = 0; i < factionsName.Count; i++)
                {
                    System.Console.WriteLine(i + factionsName[i]);
                }
                int factionNum = Convert.ToInt32(System.Console.ReadLine());
                players.Add(new Player(name, turnos[players.Count], factions[factionNum], new Board(31)));
                
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
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        for (int i = 0; i < TokenBank.Earth.Count; i++)
                        {
                            if(!numFichas.Contains(i))
                            {
                                System.Console.WriteLine(i + ". "+TokenBank.Earth[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        int n = int.Parse(Console.ReadLine()??string.Empty);
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
                if (players[i].TurnActive == true)
                {
                    Console.Clear();
                    PrintToken(players, i);
                    System.Console.WriteLine(players[i].Name + " Seleccione la ficha que desea mover");
                    for (int j = 0; j < players[i].Selected.Count; j++)
                    {
                        System.Console.WriteLine(j + " " + players[i].Selected [j].ToString());
                    }
                    int n = int.Parse(Console.ReadLine()??string.Empty);
                    Token FichaActual = players[i].Selected[n];
                    int Speed = FichaActual.Speed;
                    if (SlowDown)
                    {
                        FichaActual.Speed -= 1;
                    }
                    SlowDown = false;
                    if (IncreaseCooldown)
                    {
                        FichaActual.CooldownActive += 1;
                    }
                    IncreaseCooldown = false;
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.P && FichaActual.CooldownActive == 0)
                    {
                        FichaActual.CooldownActive = FichaActual.Cooldown;
                        if (FichaActual.powers == PowersBank.Powers.SpeedPower)
                        {
                            PowersBank.SpeedPower(FichaActual);
                        }
                        else if (FichaActual.powers == PowersBank.Powers.GetThroughObstacles)
                        {
                            PowersBank.GetThroughObstacles(FichaActual, players[i]);
                            PassTurn(i);
                            continue;
                        }
                        else if(FichaActual.powers == PowersBank.Powers.InmuneTraps)
                        {
                            PowersBank.InmuneTraps(FichaActual);
                        }
                        else if (FichaActual.powers == PowersBank.Powers.SkipTurn)
                        {
                            PassTurn(i);
                            if (i + 1 < players.Count)
                            {
                                PassTurn(i + 1);
                            }
                            else
                            {
                                PassTurn(0);
                            }
                            continue;
                        }
                        else if (FichaActual.powers == PowersBank.Powers.SlowDown)
                        {
                            PowersBank.SlowDown(FichaActual);
                            SlowDown = true;
                        }
                        else if (FichaActual.powers == PowersBank.Powers.IncreaseCooldown)
                        {
                            PowersBank.IncreaseCooldown(FichaActual);
                            IncreaseCooldown = true;
                        }
                    }
                    int vel = 0;
                    while (vel <= FichaActual.Speed)
                    {
                        tecla = Console.ReadKey(true);
                        Console.Clear();
                        if (tecla.Key == ConsoleKey.UpArrow && players[i].board.matriz[FichaActual.PosFil - 1, FichaActual.PosCol])
                        {
                            FichaActual.PosFil += -1;
                            
                        }
                        else if (tecla.Key == ConsoleKey.DownArrow && players[i].board.matriz[FichaActual.PosFil + 1, FichaActual.PosCol])
                        {
                           FichaActual.PosFil += 1;
                        }
                        else if (tecla.Key == ConsoleKey.RightArrow && players[i].board.matriz[FichaActual.PosFil, FichaActual.PosCol + 1])
                        {
                            FichaActual.PosCol += 1;
                        }
                        else if (tecla.Key == ConsoleKey.LeftArrow && players[i].board.matriz[FichaActual.PosFil, FichaActual.PosCol - 1])
                        {
                           FichaActual.PosCol += -1;
                        }
                        if (players[i].board.board[FichaActual.PosFil, FichaActual.PosCol] is Traps traps && traps.IsActive)
                        {
                            if (traps.trapstypes == TrapsTypes.MissTurn)
                            {
                                traps.IsActive = false;
                                System.Console.WriteLine("Has Caido en una trampa y has perdido el turno");
                                break;
                            }
                            else if (traps.trapstypes == TrapsTypes.BackToStart)
                            {
                                FichaActual.PosFil = 1;
                                FichaActual.PosCol = 1;
                                traps.IsActive = false;
                                System.Console.WriteLine("Has caido en una trampa y has vuelto al inicio");
                                break;
                            }
                            else if (traps.trapstypes == TrapsTypes.ResetCooldown)
                            {
                                FichaActual.CooldownActive = FichaActual.Cooldown;
                                traps.IsActive = false;
                                System.Console.WriteLine("Has caido en una trampa y tu cooldown ha sido reiniciado");
                            }
                            else if (traps.trapstypes == TrapsTypes.GetSlow)
                            {
                                FichaActual.Speed = 1;
                                traps.IsActive = false;
                                System.Console.WriteLine("Has caido en una trampa y tu velicidad se ha reducido a 1");
                            }
                        }
                        PrintToken(players, i);
                        vel ++;
                    }
                    if (FichaActual.powers == PowersBank.Powers.SpeedPower && FichaActual.PowerActive)
                    {
                        FichaActual.Speed -= 3;
                    }
                    if (WinCondition(players[i]))
                    {
                        throw new Exception ($"Ha ganado el jugador {players[i].Name}");
                    }
                    FichaActual.Speed = Speed;
                    FichaActual.PowerActive = false;
                    //if(tecla.Key == )
                    PassTurn(i);
                }
            }
        }
    }
    public void DecreaseCooldown(List<Player> players)
    {
       for (int i = 0; i < players.Count; i++)
       {
            for (int j = 0; j < 3; j++)
            {
                players[i].Selected[j].CooldownActive -= 1;
            }
       }
    }
   
    public bool WinCondition(Player player)
    {
        bool Win = false;
        for (int i = 0; i < players.Count; i++)
        {
            if (player.Selected[i].PosFil == player.board.filas - 2 && player.Selected[i].PosCol == player.board.columnas - 2)
            {
                Win = true;
            }
            else
            {
                Win = false;
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
}