class Program
{
    static void Main(string[] args)
    {
        Board map = new Board (31);
        map.GenMatrix();

        for (int i = 0; i < map.filas; i++)
        {
            for (int j = 0; j < map.columnas; j++)
            {
                if(map.matriz[i,j]) System.Console.Write("  ");
                else System.Console.Write("██");
            }
            System.Console.WriteLine();
        }
    }
    
}

    


