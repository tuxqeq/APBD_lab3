namespace APBD_lab3;

public class GasContainer : Container, IHazardInterface
{
    public double Preassure { get; set; }
    
    public GasContainer(int massOfCargo, int height, int tareWeight, double weightOfCargo, int depth, double maxPayload, double preassure)
        : base(massOfCargo, height, tareWeight, weightOfCargo, depth, "G", maxPayload)
    {
        Preassure = preassure;
    }

    public override void EmptyCargo()
    {
        WeightOfCargo = 0.05 * WeightOfCargo;
    }
    
    public void sendTextNotification()
    {
        Console.WriteLine($"A hazardous operation was performed on container {SerialNumber}");
    }
}