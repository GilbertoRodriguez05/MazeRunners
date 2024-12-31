using System.Net.Http.Headers;
using System.Net.NetworkInformation;

class Token
{
    public string Name;
    public string Info;
    public Factions Faction;
    public int Speed;
    public int Cooldown;
    public int CooldownActive;
    public bool PowerActive;
    public PowersBank.Powers powers;
    public int PosFil = 1;
    public int PosCol = 1;
    public Token (string Name, string Info, Factions Faction, int Speed, int Cooldown, PowersBank.Powers powers, bool PowerActive)
    {
        this.Name = Name;
        this.Info = Info;
        this.Faction = Faction;
        this.Speed = Speed;
        this.Cooldown = Cooldown;
        this.powers = powers;
        this.PowerActive = PowerActive;
        this.CooldownActive = Cooldown;
    }

    public override string ToString()
    {
        return "Nombre: " + Name + " | Velocidad: " + Speed + " | Cooldown: " + Cooldown + " | Poder: " +  Info;
    }
}
public enum Factions
    {
        Fire,
        Earth,
        Water,
        Wind
    }
    
class TokenBank
{
    //Faccion Fuego
    public static Token FastFlame = new Token("FastFlame      ", "Aumenta su velocidad", Factions.Fire, 1, 3, PowersBank.Powers.SpeedPower, false);
    public static Token FireExplosion = new Token("FireExplosion  ", "Puede atravesar un obstaculo", Factions.Fire, 2, 5, PowersBank.Powers.GetThroughObstacles, false);
    public static Token RebornPhoenix = new Token("RebornPhoenix  ", "Se hace inmune a las trampas", Factions.Fire, 3, 4, PowersBank.Powers.InmuneTraps, false);
    public static Token ScorchingHeat = new Token("ScorchingHeat  ", "Salta el turno del proximo jugador", Factions.Fire, 2, 3, PowersBank.Powers.SkipTurn, false);
    public static Token BurningFury = new Token("BurningFury    ", "Disminuye 1 pto la velocidad del proximo jugador", Factions.Fire, 2, 3, PowersBank.Powers.SlowDown, false);
    public static Token HellFire = new Token("HellFire       ", "Aumenta 1 turno el cooldown del proximo jugador", Factions.Fire, 3, 2, PowersBank.Powers.IncreaseCooldown, false);
    public static List<Token> Fire = new List<Token> {FastFlame, FireExplosion, RebornPhoenix, ScorchingHeat, BurningFury, HellFire};


    //Faccion Agua
    public static Token PropellingGeyser = new Token("PropellingGeyser  ", "Aumenta su velocidad", Factions.Water, 1, 3, PowersBank.Powers.SpeedPower, false);
    public static Token FlowingStream = new Token("FlowingStream     ", "Puede atravesar un obstaculo", Factions.Water, 2, 5, PowersBank.Powers.GetThroughObstacles, false);
    public static Token HealingRain = new Token ("HealingRain       ", "Se hace inmune a las trampas", Factions.Water, 3, 4, PowersBank.Powers.InmuneTraps, false);
    public static Token SlipperyIce = new Token("SlipperyIce       ", "Salta el turno del proximo jugador", Factions.Water, 2, 3, PowersBank.Powers.SkipTurn, false);
    public static Token FrostyBreeze = new Token("FrostBreeze       ", "Disminuye 1 pto la velocidad del proximo jugador", Factions.Water, 2, 3, PowersBank.Powers.SlowDown, false);
    public static Token Tsunami = new Token("Tsunami           ", "Aumenta 1 turno el cooldown del proximo jugador", Factions.Water, 3, 2, PowersBank.Powers.IncreaseCooldown, false);
    public static List<Token> Water = new List<Token> {PropellingGeyser, FlowingStream, HealingRain, SlipperyIce, FrostyBreeze, Tsunami};


    //Faccion Viento
    public static Token GustWind = new Token("GustWind     ", "Aumenta su velocidad", Factions.Wind, 1, 3, PowersBank.Powers.SpeedPower, false);
    public static Token Typhoon = new Token("Typhoon      ", "Puede atravesar un obstaculo", Factions.Wind, 2, 5, PowersBank.Powers.GetThroughObstacles, false);
    public static Token WindWhisper = new Token("WindWhisper  ", "Se hace inmune a las trampas", Factions.Wind, 3, 4, PowersBank.Powers.InmuneTraps, false);
    public static Token Tornado = new Token("Tornado      ", "Salta el turno del proximo jugador", Factions.Wind, 2, 3, PowersBank.Powers.SkipTurn, false);
    public static Token Cyclon = new Token("Cyclon       ", "Disminuye 1 pto la velocidad del proximo jugador", Factions.Wind, 2, 3, PowersBank.Powers.SlowDown, false);
    public static Token Storm = new Token("Storm        ", "Aumenta 1 turno el cooldown del proximo jugador", Factions.Wind, 3, 2, PowersBank.Powers.IncreaseCooldown, false);
    public static List<Token> Wind = new List<Token> {GustWind, Typhoon, WindWhisper, Tornado, Cyclon, Storm};


    //Faccion Tierra
    public static Token SwiftCreeper = new Token("SwiftCreeper    ", "Aumenta su velocidad", Factions.Earth, 1, 3, PowersBank.Powers.SpeedPower, false);
    public static Token Earthquake = new Token("EarthQauke      ", "Puede atravesar un obstaculo", Factions.Earth, 2, 5, PowersBank.Powers.GetThroughObstacles, false);
    public static Token HealingNature = new Token("HealingNature   ", "Se hace inmune a las trampas", Factions.Earth, 3, 4, PowersBank.Powers.InmuneTraps, false);
    public static Token StoneFist = new Token("StoneFist       ", "Salta el turno del proximo jugador", Factions.Earth, 2, 3, PowersBank.Powers.SkipTurn, false);
    public static Token QuickSand = new Token("QuickSand       ", "Disminuye 1 pto la velocidad del proximo jugador", Factions.Earth, 2, 3, PowersBank.Powers.SlowDown, false);
    public static Token EarthShake = new Token("EarthShake      ", "Aumenta 1 turno el cooldown del proximo jugador", Factions.Earth, 3, 2, PowersBank.Powers.IncreaseCooldown, false);
    public static List<Token> Earth = new List<Token> {SwiftCreeper, Earthquake, HealingNature, StoneFist, QuickSand, EarthShake};
        
    }