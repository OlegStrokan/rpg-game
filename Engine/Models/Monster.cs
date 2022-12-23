
namespace Engine.Models;

public class Monster : LivingEntity
{
    public string ImageName { get; set; }
    public int MinimumDamage { get; set; }
    public int MaximumDamage { get; set; }
    
    public int RewardExperiencePoints { get; private set; }

    public Monster(
        string name,
        string imageName, 
        int maximumHitPoints,
        int currentHitPoints, 
        int rewardExperiencePoints,
        int rewardGold,
        int minimumDatage,
        int maximumDamage
            ) : base(name, maximumHitPoints, currentHitPoints, rewardGold)
    {
        ImageName = $"/Engine;component/Images/Monsters/{imageName}";
        RewardExperiencePoints = rewardExperiencePoints;
        MinimumDamage = minimumDatage;
        MaximumDamage = maximumDamage;
    }
}