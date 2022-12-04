using System.Collections.ObjectModel;

namespace Engine.Models;

public class Monster : BaseNotification
{
    private int _hitPoints;
    
    public string Name { get; set; }
    public string ImageName { get; set; }
    public int MaximumHitPoints { get; set; }

    public int HitPoints
    {
        get { return _hitPoints; }
         set
        {
            _hitPoints = value;
            OnPropertyChanged(nameof(HitPoints));
        }
    }
    
    public int MinimumDamage { get; set; }
    public int MaximumDamage { get; set; }
    
    public int RewardExperiencePoints { get; private set; }
    public int RewardGold { get; private set; }
    
    public ObservableCollection<ItemQuantity> Inventory { get; set; }

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
        HitPoints = hitPoints;
        RewardExperiencePoints = rewardExperiencePoints;
        RewardGold = rewardGold;
        MinimumDamage = minimumDatage;
        MaximumDamage = maximumDamage;

        Inventory = new ObservableCollection<ItemQuantity>();
    }
}