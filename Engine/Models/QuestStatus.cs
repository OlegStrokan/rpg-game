namespace Engine.Models;

public class QuestStatus : BaseNotification
{
    public Quest PlayerQuest { get; }

    private bool _isCompleted;

    public bool IsCompleted
    {
        get { return _isCompleted; }
        set
        {
            _isCompleted = value;
            OnPropertyChanged();
        }
    }

    public QuestStatus(Quest quest)
    {
        PlayerQuest = quest;
        IsCompleted = false;
    }
}