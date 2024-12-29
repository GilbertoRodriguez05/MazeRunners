class GameManager
{
    List<Player> players = new List<Player>();
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
        // List<string> FireTokens = new List<string> {". Nombre: FastFlame      | Velocidad: 1  | Cooldown: 3  | Poder: Aumenta su velocidad", 
        //                                             ". Nombre: FireExplosion  | Velocidad: 2  | Cooldown: 5  | Poder: Puede atravesar un obstaculo", 
        //                                             ". Nombre: RebornPhoenix  | Velocidad: 3  | Cooldown: 4  | Poder: Se hace inmune a las trampas", 
        //                                             ". Nombre: ScorchingHeat  | Velocidad: 2  | Cooldown: 3  | Poder: Salta el turno del proximo jugador", 
        //                                             ". Nombre: BurningFury    | Velocidad: 2  | Cooldown: 3  | Poder: Disminuye 1 punto la velocidad del proximo jugador", 
        //                                             ". Nombre: HellFire       | Velocidad: 3  | Cooldown: 2  | Poder: Aumenta 1 turno el cooldown del proximo jugador"};
        // List<string> WaterTokens = new List<string>{". Nombre: PropellingGeyser  | Velocidad: 1  | Cooldown: 3  | Poder: Aumenta su velocidad", 
        //                                             ". Nombre: FlowingStream     | Velocidad: 2  | Cooldown: 5  | Poder: Puede atravesar un obstaculo", 
        //                                             ". Nombre: HealingRain       | Velocidad: 3  | Cooldown: 4  | Poder: Se hace inmune a las trampas", 
        //                                             ". Nombre: SlipperyIce       | Velocidad: 2  | Cooldown: 3  | Poder: Salta el turno del proximo jugador", 
        //                                             ". Nombre: FrostBreeze       | Velocidad: 2  | Cooldown: 3  | Poder: Disminuye 1 pto la velocidad del proximo jugador", 
        //                                             ". Nombre: Tsunami           | Velocidad: 3  | Cooldown: 2  | Poder: Aumenta 1 turno el cooldown del proximo jugador"};
        // List<string> WindTokens = new List<string> {". Nombre: GustWind     | Velocidad: 1   | Cooldown: 3  | Poder: Aumenta su velocidad", 
        //                                             ". Nombre: Typhoon      | Velocidad: 2   | Cooldown: 5  | Poder: Puede atravesar un obstaculo", 
        //                                             ". Nombre: WindWhisper  | Velocidad: 3   | Cooldown: 4  | Poder: Se hace inmune a las trampas", 
        //                                             ". Nombre: Tornado      | Velocidad: 2   | Cooldown: 3  | Poder: Salta el turno del proximo jugador", 
        //                                             ". Nombre: Cyclon       | Velocidad: 2   | Cooldown: 3  | Poder: Disminuye 1 pto la velocidad del proximo jugador", 
        //                                             ". Nombre: Storm        | Velocidad: 3   | Cooldown: 2  | Poder: Aumenta 1 turno el cooldown del proximo jugador"};
        // List<string> EarthTokens = new List<string>{". Nombre: SwiftCreeper    | Velocidad: 1  | Cooldown: 3  | Poder: Aumenta su velocidad", 
        //                                             ". Nombre: EarthQauke      | Velocidad: 2  | Cooldown: 5  | Poder: Puede atravesar un obstaculo", 
        //                                             ". Nombre: HealingNature   | Velocidad: 3  | Cooldown: 4  | Poder: Se hace inmune a las trampas", 
        //                                             ". Nombre: StoneFist       | Velocidad: 2  | Cooldown: 3  | Poder: Salta el turno del proximo jugador", 
        //                                             ". Nombre: QuickSand       | Velocidad: 2  | Cooldown: 3  | Poder: Disminuye 1 pto la velocidad del proximo jugador", 
        //                                             ". Nombre: EarthShake      | Velocidad: 3  | Cooldown: 2  | Poder: Aumenta 1 turno el cooldown del proximo jugador"};
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
                players.Add(new Player(name, turnos[players.Count], factions[factionNum]));
                
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
    public void Play(Board map)
    {
        while (true)
        {
            bool SlowDown = false;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].TurnActive == true)
                {
                    System.Console.WriteLine("Seleccione la ficha que desea mover");
                    for (int j = 0; j < players[i].Selected.Count; j++)
                    {
                        System.Console.WriteLine(players[i].Selected [j].ToString());
                    }
                    int n = int.Parse(Console.ReadLine()??string.Empty);
                    Token FichaActual = players[i].Selected[n];
                    int Speed = FichaActual.Speed;
                    if (SlowDown)
                    {
                        FichaActual.Speed -= 1;
                    }
                    SlowDown = false;
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.P)
                    {
                        if (FichaActual.powers == PowersBank.Powers.SpeedPower)
                        {
                            PowersBank.SpeedPower(FichaActual);
                        }
                        else if (FichaActual.powers == PowersBank.Powers.GetThroughObstacles)
                        {
                            PowersBank.GetThroughObstacles(FichaActual, map);
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
                            PassTurn(i + 1);
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
                        }
                    }
                    int vel = 0;
                    while (vel <= FichaActual.Speed)
                    {
                        if (tecla.Key == ConsoleKey.UpArrow && map.matriz[FichaActual.PosFil - 1, FichaActual.PosCol])
                        {
                            FichaActual.PosFil += -1;
                        }
                        else if (tecla.Key == ConsoleKey.DownArrow && map.matriz[FichaActual.PosFil + 1, FichaActual.PosCol])
                        {
                           FichaActual.PosFil += 1;
                        }
                        else if (tecla.Key == ConsoleKey.RightArrow && map.matriz[FichaActual.PosFil, FichaActual.PosCol + 1])
                        {
                            FichaActual.PosCol += 1;
                        }
                        else if (tecla.Key == ConsoleKey.LeftArrow && map.matriz[FichaActual.PosFil, FichaActual.PosCol - 1])
                        {
                           FichaActual.PosCol += -1;
                        }
                        vel ++;
                    }
                    if (FichaActual.powers == PowersBank.Powers.SpeedPower && FichaActual.PowerActive)
                    {
                        FichaActual.Speed -= 3;
                    }
                    FichaActual.Speed = Speed;
                    FichaActual.PowerActive = false;
                    PassTurn(i);
                }
            }
        }
    }
    public void GetPower(Token token)
    {
       
    }
}