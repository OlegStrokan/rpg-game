namespace Engine.Utils;

public  class TraderHere : LocationBase
{
    public string TraderName;

    public TraderHere(string traderName, string locationName) : base(locationName)
    {
        TraderName = traderName;
    }
}