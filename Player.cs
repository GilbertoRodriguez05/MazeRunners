class Player
{
    public List<Token> Select;
    public List<Token> Selected;
    public Factions factions;
    public string Name;
    public Turn turn;
    public Player(string Name, Turn turn, Factions factions)
    {
        this.Name = Name;
        this.turn = turn;
        this.Select = new List<Token>{};
        this.Selected = new List<Token>{};
        this.factions = factions;
        GetTokens(factions);
    }

    public void GetTokens(Factions factions)
    {
        if (factions == Factions.Earth)
        {
            Select = new List<Token> (TokenBank.Earth);
        }
        else if (factions == Factions.Fire)
        {
            Select = new List<Token> (TokenBank.Fire);
        }
        else if (factions == Factions.Water)
        {
            Select = new List<Token> (TokenBank.Water);
        }
        else if (factions == Factions.Wind)
        {
            Select = new List<Token> (TokenBank.Wind);
        }
    }

}
enum Turn
{
    Turn1,
    Turn2,
    Turn3,
    Turn4
}