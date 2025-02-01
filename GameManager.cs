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

        int playersNum = 0;
        while(playersNum < 4)
        {
            System.Console.WriteLine("Escriba el nombre del jugador");
            string name = System.Console.ReadLine()?? string.Empty;
            if(string.IsNullOrEmpty(name))
            {
                break;
            }
            else
            {
                string faction;
                int factionNum;
                while (true)
                {
                    System.Console.WriteLine("Seleccione el numero de la faccion deseada: ");
                    for (int i = 0; i < factionsName.Count; i++)
                    {
                        System.Console.WriteLine(i + factionsName[i]);
                    }
                    faction = System.Console.ReadLine()?? string.Empty;
                    if(!IsNumeric(faction) || string.IsNullOrEmpty(faction)) continue;
                    factionNum = Convert.ToInt32(faction);
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
                
                if (players[playersNum].factions == Factions.Fire)
                {
                    int tokens = 0;
                    List<int> TokenNum = new List<int>();

                    while (tokens < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < TokenBank.Fire.Count; i++)
                        {
                            if(!TokenNum.Contains(i))
                            {
                                System.Console.WriteLine(i + ". " + TokenBank.Fire[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        string s = Console.ReadLine()??string.Empty;
                        if ( !IsNumeric(s) || string.IsNullOrEmpty(s))
                        {
                            continue;
                        }
                        int n = int.Parse(s);
                        if (n < 0 || n > TokenBank.Fire.Count - 1)
                        {
                            continue;
                        }
                        if (TokenNum.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        TokenNum.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Fire[n]);
                        Console.Clear();
                        if (tokens == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        tokens ++;
                    }
                }
                else if (players[playersNum].factions == Factions.Water)
                {
                    int tokens = 0;
                    List<int> TokenNum = new List<int>();

                    while (tokens < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 0; i < TokenBank.Water.Count; i++)
                        {
                            if(!TokenNum.Contains(i))
                            {
                                System.Console.WriteLine(i + ". " + TokenBank.Water[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        string s = Console.ReadLine()??string.Empty;
                        if  (!IsNumeric(s) || string.IsNullOrEmpty(s))
                        {
                            continue;
                        }
                        int n = int.Parse(s);
                        if (n < 0 || n > TokenBank.Water.Count - 1)
                        {
                            continue;
                        }
                        if (TokenNum.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        TokenNum.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Water[n]);
                        Console.Clear();
                        if (tokens == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        tokens ++;
                    }
                }
                else if (players[playersNum].factions == Factions.Wind)
                {
                    int tokens = 0;
                    List<int> TokenNum = new List<int>();

                    while (tokens < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        for (int i = 0; i < TokenBank.Wind.Count; i++)
                        {
                            if(!TokenNum.Contains(i))
                            {
                                System.Console.WriteLine(i + ". " + TokenBank.Wind[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        string s = Console.ReadLine()??string.Empty;
                        if (!IsNumeric(s) || string.IsNullOrEmpty(s))
                        {
                            continue;
                        }
                        int n = int.Parse(s);
                        if (n < 0 || n > TokenBank.Wind.Count - 1)
                        {
                            continue;
                        }
                        if (TokenNum.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        TokenNum.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Wind[n]);
                        Console.Clear();
                        if (tokens == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        tokens ++;
                    }
                }
                else if (players[playersNum].factions == Factions.Earth)
                {
                    int tokens = 0;
                    List<int> TokenNum = new List<int>();

                    while (tokens < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < TokenBank.Earth.Count; i++)
                        {
                            if(!TokenNum.Contains(i))
                            {
                                System.Console.WriteLine(i + ". "+TokenBank.Earth[i].ToString());
                            }
                        }
                        Console.ResetColor();
                        string s = Console.ReadLine()??string.Empty;
                        if ( !IsNumeric(s) || string.IsNullOrEmpty(s))
                        {
                            continue;
                        }
                        int n = int.Parse(s);
                        if (n < 0 || n > TokenBank.Earth.Count - 1)
                        {
                            continue;
                        }
                        if (TokenNum.Contains(n))
                        {
                            Console.Clear();
                            System.Console.WriteLine("Seleccione una distinta");
                            continue;
                        }
                        TokenNum.Add(n);
                        players[players.Count-1].Selected.Add(TokenBank.Earth[n]);
                        Console.Clear();
                        if (tokens == 2)
                        {
                            break;
                        }
                        System.Console.WriteLine("Seleccione otra");
                        tokens ++;
                    }
                }
            }
            players [0].TurnActive = true;
            playersNum++;
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
        TokenIcon();
        bool SlowDown = false;
        bool IncreaseCooldown = false;
        while (true)
        {
            DecreaseCooldown(players);
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
                        IncreaseCooldown = false;
                    }
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
                        string s = Console.ReadLine()??string.Empty;
                        if ( !IsNumeric(s) || string.IsNullOrEmpty(s))
                        {
                            continue;
                        }
                        n = int.Parse(s);
                        if (n >= 0 && n < players[i].Selected.Count)
                        {
                            if (players[i].Selected[n].PosCol == players[i].board.columnas-2 && players[i].Selected[n].PosFil == players[i].board.filas-2)
                            {
                                Console.Clear();
                                System.Console.WriteLine("Esta ficha ya esta en la posicion final");
                                Thread.Sleep(3000);
                                continue;
                            }
                            else break;
                        }
                    }
                    Token ActualToken = players[i].Selected[n];
                    int Speed = ActualToken.Speed;
                    if (SlowDown)
                    {
                        ActualToken.Speed -= 1;
                        SlowDown = false;
                    }
                    
                    int vel = 1;
                    while (vel <= ActualToken.Speed)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        Console.Clear();
                        

                        if (key.Key == ConsoleKey.P && ActualToken.CooldownActive == 0 && vel == 1)
                        {
                            System.Console.WriteLine("Activaste el poder");
                            Thread.Sleep(1000);
                            ActualToken.CooldownActive = ActualToken.Cooldown;
                            if (ActualToken.powers == PowersBank.Powers.SpeedPower)
                            {
                                Console.Clear();
                                PowersBank.SpeedPower(ActualToken);
                            }
                            else if (ActualToken.powers == PowersBank.Powers.GetThroughObstacles)
                            {
                                PrintToken(players, i);
                                PowersBank.GetThroughObstacles(ActualToken, players[i]);
                                PassTurn(i);
                                break;
                            }
                            else if(ActualToken.powers == PowersBank.Powers.InmuneTraps)
                            {
                                Console.Clear();
                                PowersBank.InmuneTraps(ActualToken);
                            }
                            else if (ActualToken.powers == PowersBank.Powers.SkipTurn)
                            {
                                if (i + 1 < players.Count)
                                {
                                    players[i + 1].PassTurn = true;
                                }
                                else
                                {
                                    players[0].PassTurn = true;
                                }
                            }
                            else if (ActualToken.powers == PowersBank.Powers.SlowDown)
                            {
                                Console.Clear();
                                PowersBank.SlowDown(ActualToken);
                                SlowDown = true;
                            }
                            else if (ActualToken.powers == PowersBank.Powers.IncreaseCooldown)
                            {
                                Console.Clear();
                                PowersBank.IncreaseCooldown(ActualToken);
                                IncreaseCooldown = true;
                            }
                        }
                        
                        if (key.Key == ConsoleKey.UpArrow && players[i].board.matriz[ActualToken.PosFil - 1, ActualToken.PosCol])
                        {
                            ActualToken.PosFil += -1;
                            vel ++;
                        }
                        else if (key.Key == ConsoleKey.DownArrow && players[i].board.matriz[ActualToken.PosFil + 1, ActualToken.PosCol])
                        {
                           ActualToken.PosFil += 1;
                           vel ++;
                        }
                        else if (key.Key == ConsoleKey.RightArrow && players[i].board.matriz[ActualToken.PosFil, ActualToken.PosCol + 1])
                        {
                            ActualToken.PosCol += 1;
                            vel ++;
                        }
                        else if (key.Key == ConsoleKey.LeftArrow && ActualToken.PosFil == 1 && ActualToken.PosCol == 0)
                        {
                            PrintToken(players, i);
                            continue;
                        }
                        else if (key.Key == ConsoleKey.LeftArrow && players[i].board.matriz[ActualToken.PosFil, ActualToken.PosCol - 1])
                        {
                           ActualToken.PosCol += -1;
                           vel ++;
                        }
                        if (players[i].board.board[ActualToken.PosFil, ActualToken.PosCol] is Traps traps && traps.IsActive)
                        {
                            if (traps.trapstypes == TrapsTypes.MissTurn)
                            {
                                traps.IsActive = false;
                                if (ActualToken.powers == PowersBank.Powers.InmuneTraps && ActualToken.PowerActive)
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
                                if (ActualToken.powers == PowersBank.Powers.InmuneTraps && ActualToken.PowerActive)
                                {
                                    System.Console.WriteLine("Has caido en una trampa pero te has protegido");
                                }
                                else
                                {
                                    ActualToken.PosFil = 1;
                                    ActualToken.PosCol = 0;
                                    System.Console.WriteLine("Has caido en una trampa y has vuelto al inicio");
                                    Thread.Sleep(3000);
                                    break;
                                }
                            }
                            else if (traps.trapstypes == TrapsTypes.ResetCooldown)
                            {
                                traps.IsActive = false;
                                if (ActualToken.powers == PowersBank.Powers.InmuneTraps && ActualToken.PowerActive)
                                {
                                    System.Console.WriteLine("Has caido en una trampa pero te has protegido");
                                }
                                else
                                {
                                    ActualToken.CooldownActive = ActualToken.Cooldown;
                                    System.Console.WriteLine("Has caido en una trampa y tu cooldown ha sido reiniciado");
                                    Thread.Sleep(3000);
                                }
                            }
                            else if (traps.trapstypes == TrapsTypes.GetSlow)
                            {
                                traps.IsActive = false;
                                if (ActualToken.powers == PowersBank.Powers.InmuneTraps && ActualToken.PowerActive)
                                {
                                    System.Console.WriteLine("Has caido en una trampa pero te has protegido");
                                }
                                else
                                {
                                    ActualToken.Speed = 1;
                                    System.Console.WriteLine("Has caido en una trampa y tu velicidad se ha reducido a 1");
                                    Thread.Sleep(3000);
                                }
                            }
                        }
                        PrintToken(players, i);
                        if (WinCondition(players[i]))
                        {
                            System.Console.WriteLine($"Ha ganado el jugador {players[i].Name}");
                            return;
                        }
                    }
                    if (ActualToken.powers == PowersBank.Powers.SpeedPower && ActualToken.PowerActive)
                    {
                        ActualToken.Speed -= 3;
                    }
                    ActualToken.Speed = Speed;
                    ActualToken.PowerActive = false;
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
                    System.Console.Write("3️⃣ ");
                }
                else if (players[i].Selected[0].PosFil == a && players [i].Selected[1].PosFil == a && players[i].Selected[0].PosCol == b && players[i].Selected[1].PosCol == b)
                {
                    System.Console.Write("2️⃣ ");
                }
                else if (players[i].Selected[0].PosFil == a && players [i].Selected[2].PosFil == a && players[i].Selected[0].PosCol == b && players[i].Selected[2].PosCol == b)
                {
                    System.Console.Write("2️⃣ ");
                }
                else if (players[i].Selected[1].PosFil == a && players [i].Selected[2].PosFil == a && players[i].Selected[1].PosCol == b && players[i].Selected[2].PosCol == b)
                {
                    System.Console.Write("2️⃣ ");
                } 
                else if (players[i].Selected[0].PosFil == a && players[i].Selected[0].PosCol == b)
                {
                    System.Console.Write(players[i].Selected[0].Icon);
                }
                else if (players[i].Selected[1].PosFil == a && players[i].Selected[1].PosCol == b)
                {
                    System.Console.Write(players[i].Selected[1].Icon);
                }
                else if (players[i].Selected[2].PosFil == a && players[i].Selected[2].PosCol == b)
                {
                    System.Console.Write(players[i].Selected[2].Icon);
                }
                else if (players[i].board.matriz [a, b])
                {
                    System.Console.Write("  ");
                }
                else
                {
                    TokenColor(players[i]);
                    System.Console.Write("██");
                }
            }
            System.Console.WriteLine();
        }
        Console.ResetColor();
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
    public void TokenIcon()
    {
       for (int i = 0; i < players.Count; i++)
       {
            if (players[i].factions == Factions.Fire)
            {
                players[i].Selected[0].Icon = "🔥";
                players[i].Selected[1].Icon = "☄️ ";
                players[i].Selected[2].Icon = "💥";
            }
            else if (players[i].factions == Factions.Water)
            {
                players[i].Selected[0].Icon = "💧";
                players[i].Selected[1].Icon = "🌊";
                players[i].Selected[2].Icon = "🫧";
            }
            else if (players[i].factions == Factions.Earth)
            {
                players[i].Selected[0].Icon = "🌴";
                players[i].Selected[1].Icon = "🌵";
                players[i].Selected[2].Icon = "🪵 ";
            }
            else if (players[i].factions == Factions.Wind)
            {
                players[i].Selected[0].Icon = "💨";
                players[i].Selected[1].Icon = "🌪️";
                players[i].Selected[2].Icon = "⚡️";
            }
       }
    }
    
    static bool IsNumeric(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false; 
            }
        }
        return true;
    }
}