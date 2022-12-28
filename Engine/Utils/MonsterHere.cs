namespace Engine.Utils;

public class MonsterHere : LocationBase
{
    public int Id;
    public int ChanceOfEncountering;

    public MonsterHere(int id, int chanceOfEncountering, string locationName) : base(locationName)
    {
        Id = id;
        ChanceOfEncountering = chanceOfEncountering;
    }
}