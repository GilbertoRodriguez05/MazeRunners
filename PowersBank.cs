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
    public static void GetThroughObstacles(Token token, Board map)
    {
        token.PowerActive = true;
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        int vel = 0;
        while (vel <= token.Speed)
        {
            if (tecla.Key == ConsoleKey.UpArrow)
            {
                if (token.PosFil - 1 > 0)
                {
                    token.PosFil += -1;
                }
            }
            else if (tecla.Key == ConsoleKey.DownArrow )
            {
               if (token.PosFil + 1 < map.filas)
               {
                token.PosFil += 1;
               }
            }
            else if (tecla.Key == ConsoleKey.RightArrow )
            {
                if (token.PosCol + 1 < map.columnas)
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