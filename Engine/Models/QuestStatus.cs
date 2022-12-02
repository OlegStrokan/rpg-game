namespace Engine.Models;

public class QuestStatus
{
    public Quest PlayerQuest { get; set; }
    public bool isCompleted { get; set; }

    public QuestStatus(Quest quest)
    {
        PlayerQuest = quest;
        isCompleted = false;
    }
}