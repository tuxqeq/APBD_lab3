namespace APBD_lab3;

public class LiquidContainer : Container, IHazardInterface
{
    public string TypeOfLiquid { get; set; }
    
    
    public LiquidContainer(int massOfCargo, int height, int tareWeight, double weightOfCargo, int depth, double maxPayload, string typeOfLiquid)
        : base(massOfCargo, height, tareWeight, weightOfCargo, depth, "L", maxPayload)
    {
        TypeOfLiquid = typeOfLiquid;
    }

    public override void LoadCargo(int weight)
    {
        double allowedPayload = TypeOfLiquid == "Hazardous" ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (weight + WeightOfCargo > allowedPayload)
        {
            sendTextNotification();
            throw new OverfillException("Too much weight");
        }
        WeightOfCargo += weight;
    }
    
    public void sendTextNotification()
    {
        Console.WriteLine($"Attempt to perform a dangerous operation on container {SerialNumber}");
    }
}
