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
        token.Speed += 3;
        token.PowerActive = true;
    }
    public static void GetThroughObstacles(Token token, Player player)
    {
        token.PowerActive = true;        
        ConsoleKeyInfo key = Console.ReadKey(true);
        for (int a = 0; a < player.board.filas; a++)
        {
            for (int b = 0; b < player.board.columnas; b++)
            {
                for (int c = 0; c < player.Selected.Count; c++)
                {
                    if (player.Selected[c].PosFil == a && player.Selected[c].PosCol == b)
                    {
                        System.Console.Write(c);
                    }
                    else if (player.board.matriz [a, b])
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
        if (key.Key == ConsoleKey.UpArrow)
        {
            if (token.PosFil - 1 > 0)
            {
                token.PosFil += -2;
            }
        }
        else if (key.Key == ConsoleKey.DownArrow )
        {
           if (token.PosFil + 1 < player.board.filas)
           {
            token.PosFil += 2;
           }
        }
        else if (key.Key == ConsoleKey.RightArrow )
        {
            if (token.PosCol + 1 < player.board.columnas)
            {
                token.PosCol += 2;
            }
        }
        else if (key.Key == ConsoleKey.LeftArrow )
        {
           if (token.PosCol - 1 > 0)
           {
            token.PosCol += -2;
           }
        }
        if (player.board.board [token.PosFil, token.PosCol] is Traps traps && traps.IsActive)
        {
            if (traps.trapstypes == TrapsTypes.MissTurn)
            {
                traps.IsActive = false;
                System.Console.WriteLine("Has Caido en una trampa y has perdido el turno");
                Thread.Sleep(3000);
            }
            else if (traps.trapstypes == TrapsTypes.BackToStart)
            {
                token.PosFil = 1;
                token.PosCol = 1;
                traps.IsActive = false;
                System.Console.WriteLine("Has caido en una trampa y has vuelto al inicio");
                Thread.Sleep(3000);
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