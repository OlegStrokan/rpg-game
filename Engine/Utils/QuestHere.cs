namespace Engine.Utils;

public class QuestHere : LocationBase
{
    public int Id;

    public QuestHere(int id, string locationName) : base(locationName)
    {
        Id = id;
    }
}