
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
        int hitPoints, 
        int rewardExperiencePoints,
        int rewardGold,
        int minimumDatage,
        int maximumDamage
            )
    {
        Name = name;
        ImageName = $"/Engine;component/Images/Monsters/{imageName}";
        MaximumHitPoints = maximumHitPoints;
        CurrentHitPoints = hitPoints;
        RewardExperiencePoints = rewardExperiencePoints;
        Gold = rewardGold;
        MinimumDamage = minimumDatage;
        MaximumDamage = maximumDamage;
    }
}