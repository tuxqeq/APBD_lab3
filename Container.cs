namespace APBD_lab3;

public class Container
{
    static int counter = 1;

    public int Id { get; set; } = counter++;
    public int MassOfCargo { get; set; }
    public int Height { get; set; }
    public int TareWeight { get; set; } 
    public double WeightOfCargo { get; set; } 
    public int Depth { get; set; } 
    public string Type { get; set; } 
    public string SerialNumber => $"KON-{Type}-{Id}";
    public double MaxPayload { get; set; } 

    
    public Container(int massOfCargo, int height, int tareWeight, double weightOfCargo, int depth, string type, double maxPayload)
    {
        MassOfCargo = massOfCargo;
        Height = height;
        TareWeight = tareWeight;
        WeightOfCargo = weightOfCargo;
        Depth = depth;
        Type = type;
        MaxPayload = maxPayload;
    }
    
    public virtual void EmptyCargo()
    {
        WeightOfCargo = 0;
    }
    
    public virtual void LoadCargo(int weight)
    {
        if (weight + WeightOfCargo > MaxPayload)
        {
            throw new OverfillException("Too much weight");
        }
        WeightOfCargo += weight;
    }
} 

public class OverfillException : Exception
{
    public OverfillException() { }

    public OverfillException(string message) 
        : base(message) { }

    public OverfillException(string message, Exception inner) 
        : base(message, inner) { }
}

