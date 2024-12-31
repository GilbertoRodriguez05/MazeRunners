class Board
{                                    
    List<(int, int)> direcciones = [(1, 0), (0, 1), (-1, 0), (0, -1)];
    public Square [,] board;
    public bool [,] matriz;
    Random rand = new Random();

    public Board(int j)
    {
        this.board = new Square [j, j];
        this.matriz = new bool [j, j];
    }
    public int filas {get{return matriz.GetLength(0);}}
    public int columnas {get{return matriz.GetLength(1);}}

    public List<(int, int)> RandomList()
    {
        List<(int, int)> newList = new List<(int, int)>(direcciones);
        for (int i = newList.Count - 1; i > 0; i--)
        {
            int k = rand.Next(i+1);
            var item = newList [k];
            newList[k] = newList[i];
            newList[i] = item;
        }
        return newList;
    }
    public bool ValidMove(int i, int j)
    {
        if (i >= filas || i < 0)
        {
            return false;
        }
        if (j >= columnas || j < 0)
        {
            return false;
        }
        if (matriz[i, j])
        {
            return false;
        }
        return true;
    }

    public void GenMatrix()
    {
        GenMatrix(1,1);
        ConnectEnter();
        ConnectExit();
        FillSquare();
        GenTraps();
    }
    private void GenMatrix(int a, int b)
    {
        matriz[a, b] = true;
        List<(int, int)> dir = RandomList();
       for (int i = 0; i < dir.Count; i++)
       {
           var tuple = dir [i];
           if (ValidMove(a + tuple.Item1*2, b + tuple.Item2*2))
           {
                matriz[a + tuple.Item1, b + tuple.Item2] = true;
                GenMatrix(a + tuple.Item1*2, b + tuple.Item2*2);
           }
       }
    }
    public void ConnectExit()
    {
        matriz [filas - 2, columnas - 1] = true;
    }
    public void ConnectEnter()
    {
        matriz [1, 0] = true;
    }
    public void FillSquare()
    {
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (matriz[i, j])
                {
                    board[i, j] = new Empty();
                }
                else
                {
                    board[i, j] = new Obstacles();
                }            
            }
        }
    }
    public void GenTraps()
    {
        int TrapsCount = 6;
        while(TrapsCount > 0)
        {
            int RandomCount = 0;
            List<TrapsTypes> RandomList = RandomTraps();
            while (RandomCount < RandomList.Count)
            {
                int i = rand.Next(filas - 1);
                int j = rand.Next(columnas - 1);
                if (i == 1 && j == 1)
                {
                    continue;
                }
                if (matriz[i, j])
                {
                    board[i, j] = new Traps(RandomList[RandomCount], true);
                    RandomCount ++;
                    TrapsCount --;
                }
                if (TrapsCount == 0)
                {
                    break;
                }
            }
        }
    }
    public List<TrapsTypes> RandomTraps()
    {
        List<TrapsTypes> types = [TrapsTypes.MissTurn, TrapsTypes.BackToStart, TrapsTypes.GetSlow, TrapsTypes.ResetCooldown];
        for (int i = types.Count - 1; i >= 0 ; i--)
        {
            int k = rand.Next(i + 1);
            TrapsTypes temp = types[k];
            types[k] = types[i];
            types[i] = temp;
        }
        return types;
    }
}

