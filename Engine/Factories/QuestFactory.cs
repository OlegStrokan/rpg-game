using System.Collections.Generic;
using System.Linq;
using Engine.Models;
using Engine.Utils;

namespace Engine.Factories;

internal static class QuestFactory
{
    private static readonly List<Quest> _quests = new List<Quest>();

    static QuestFactory()
    {
        _quests = new List<Quest>(ConvertToQuest.ConvertData("quests.json"));

    }

    internal static Quest GetQuestByID(int id)
    {
        return _quests.FirstOrDefault(quest => quest.ID == id);
    }
}