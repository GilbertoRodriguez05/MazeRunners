using System.Threading.Tasks.Dataflow;

class Traps: Empty
{
    Random random = new Random();
    public bool IsActive = true;
    public TrapsTypes trapstypes;
    public Traps(TrapsTypes trapstypes, bool IsActive)
    {
        this.IsActive = IsActive;
        this.trapstypes = trapstypes;
    }
}

public enum TrapsTypes
{
    MissTurn,
    BackToStart,
    ResetCooldown,
    GetSlow
}
