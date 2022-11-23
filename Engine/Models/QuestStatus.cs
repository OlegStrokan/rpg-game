namespace Engine.Models;

public class QuestStatus
{
    public Quest PlayerQuest { get; set; }
    public bool isComplete { get; set; }

    public QuestStatus(Quest quest)
    {
        PlayerQuest = quest;
        isComplete = false;
    }
}