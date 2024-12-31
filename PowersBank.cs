class PowersBank
{
    public enum Powers
    {
        SpeedPower,
        GetThroughObstacles,
        InmuneTraps,
        SkipTurn,
        SlowDown,
        IncreaseCooldown
    }
    public static void SpeedPower(Token token)
    {
        token.Speed = 4;
        token.PowerActive = true;
    }
    public static void GetThroughObstacles(Token token, Player player)
    {
        token.PowerActive = true;
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        int vel = 0;
        while (vel <= token.Speed)
        {
            Console.Clear();
            for (int a = 0; a < player.board.filas; a++)
            {
                for (int b = 0; b < player.board.columnas; b++)
                {
                    for (int c = 0; c < player.Selected.Count; c++)
                    {
                        if (player.Selected[c].PosFil == a && player.Selected[c].PosCol == b)
                        {
                            System.Console.WriteLine(c);
                        }
                        else if (player.board.matriz [a, b])
                        {
                            System.Console.WriteLine("  ");
                        }
                        else
                        {
                            System.Console.WriteLine("██");
                        }
                    }
                }
            }
            if (tecla.Key == ConsoleKey.UpArrow)
            {
                if (token.PosFil - 1 > 0)
                {
                    token.PosFil += -1;
                }
            }
            else if (tecla.Key == ConsoleKey.DownArrow )
            {
               if (token.PosFil + 1 < player.board.filas)
               {
                token.PosFil += 1;
               }
            }
            else if (tecla.Key == ConsoleKey.RightArrow )
            {
                if (token.PosCol + 1 < player.board.columnas)
                {
                    token.PosCol += 1;
                }
            }
            else if (tecla.Key == ConsoleKey.LeftArrow )
            {
               if (token.PosCol - 1 > 0)
               {
                token.PosCol += -1;
               }
            }
            if (player.board.board [token.PosFil, token.PosCol] is Traps traps && traps.IsActive)
            {
                if (traps.trapstypes == TrapsTypes.MissTurn)
                {
                    traps.IsActive = false;
                    System.Console.WriteLine("Has Caido en una trampa y has perdido el turno");
                    break;
                }
                else if (traps.trapstypes == TrapsTypes.BackToStart)
                {
                    token.PosFil = 1;
                    token.PosCol = 1;
                    traps.IsActive = false;
                    System.Console.WriteLine("Has caido en una trampa y has vuelto al inicio");
                    break;
                }
                else if (traps.trapstypes == TrapsTypes.ResetCooldown)
                {
                    token.CooldownActive = token.Cooldown;
                    traps.IsActive = false;
                    System.Console.WriteLine("Has caido en una trampa y tu cooldown ha sido reiniciado");
                }
                else if (traps.trapstypes == TrapsTypes.GetSlow)
                {
                    token.Speed = 1;
                    traps.IsActive = false;
                    System.Console.WriteLine("Has caido en una trampa y tu velicidad se ha reducido a 1");
                }
            }
            vel ++;
        }
        token.PowerActive = false;
    }
    public static void InmuneTraps(Token token)
    {
        token.PowerActive = true;
    }
    public static void SkipTurn(Token token)
    {
        token.PowerActive = true;
    }
    public static void SlowDown(Token token)
    {
        token.PowerActive = true;
    }
    public static void IncreaseCooldown(Token token)
    {
        token.PowerActive = true;
    }
    
}