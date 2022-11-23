namespace Engine.Models;

public class MonsterEncounter{
    public int MonsterID { get; set; }
    public int ChangeOfEncountering { get; set; }

    public MonsterEncounter(int monsterID, int changeOfEncountering)
    {
        MonsterID = monsterID;
        ChangeOfEncountering = changeOfEncountering;
    }
}