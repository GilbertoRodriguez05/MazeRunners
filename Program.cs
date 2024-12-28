class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();

        // Board map = new Board (31);
        // map.GenMatrix();
        // int PosX = 0;
        // int PosY = 1;

        // while (true)
        // {
        //     Console.Clear();
            
        //     for (int i = 0; i < map.filas; i++)
        //     {
        //         for (int j = 0; j < map.columnas; j++)
        //         {
        //             if (i == PosY && j == PosX)
        //             {
        //                 System.Console.Write("P ");
        //             }
        //             else if(map.matriz[i,j]) System.Console.Write("  ");
        //             else System.Console.Write("██");
        //         }
        //         System.Console.WriteLine();
        //     }
        //     if (PosY == map.filas - 2 && PosX == map.columnas - 1)
        //     {
        //         System.Console.WriteLine("WIIIIIN");
        //         break;
        //     }
        //     ConsoleKeyInfo tecla = Console.ReadKey(true);
            
        //     if (tecla.Key == ConsoleKey.UpArrow && map.matriz[PosY - 1, PosX])
        //     {
        //         PosY += -1;
        //     }
        //     else if (tecla.Key == ConsoleKey.DownArrow && map.matriz[PosY + 1, PosX])
        //     {
        //         PosY += 1;
        //     }
        //     else if (tecla.Key == ConsoleKey.RightArrow && map.matriz[PosY, PosX + 1])
        //     {
        //         PosX += 1;
        //     }
        //     else if (tecla.Key == ConsoleKey.LeftArrow && map.matriz[PosY, PosX - 1])
        //     {
        //         PosX += -1;
        //     }
        // }
        
    }
    
}

    


