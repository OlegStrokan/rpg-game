
namespace Engine.Models;

public class Monster : LivingEntity
{
    public int Id { get; set; }
    public string ImageName { get; set; }
    public int MinimumDamage { get; set; }
    public int MaximumDamage { get; set; }
    
    public int RewardExperiencePoints { get; private set; }

    public Monster(
        int id,
        string name,
        string imageName, 
        int maximumHitPoints,
        int currentHitPoints, 
        int rewardExperiencePoints,
        int rewardGold,
        int minimumDamage,
        int maximumDamage
            ) : base(name, maximumHitPoints, currentHitPoints, rewardGold)
    {
        Id = id;
        ImageName = $"/Engine;component/Images/Monsters/{imageName}";
        RewardExperiencePoints = rewardExperiencePoints;
        MinimumDamage = minimumDamage;
        MaximumDamage = maximumDamage;
    }
}