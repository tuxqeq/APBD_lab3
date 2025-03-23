namespace APBD_lab3;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; set; }
    public string ProductType { get; set; }
    public Dictionary<string, double> ProductTemp { get; set; }
    
    public RefrigeratedContainer(int massOfCargo, int height, int tareWeight, double weightOfCargo, int depth, double maxPayload, double temperature, string productType)
        : base(massOfCargo, height, tareWeight, weightOfCargo, depth, "C", maxPayload)
    {
        ProductTemp = new Dictionary<string, double>
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };
        
        if (!ProductTemp.ContainsKey(productType))
        {
            throw new ArgumentException("Product type is not supported");
        }
        
        if (temperature < ProductTemp[productType])
        {
            throw new ArgumentException($"Temperature of the container cannot be lower than the temperature required by: \"{productType}\"");
        }
        
        Temperature = temperature;
        ProductType = productType;
    }
    
    
}