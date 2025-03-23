namespace APBD_lab3;

public class ContainerShip
{
    private List<Container> containers;
    public int MaxContainers { get; set; }
    public int MaxWeight { get; set; }
    public int MaxSpeed { get; set; }
    
    public ContainerShip(int maxContainers, int maxWeight, int maxSpeed)
    {
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        MaxSpeed = maxSpeed;
        containers = new List<Container>();
    }
    
    public void AddContainer(Container container)
    {
        if (containers.Count >= MaxContainers)
        {
            throw new OverfillException("Too many containers");
        }
        if (containers.Sum(c => c.WeightOfCargo) + container.WeightOfCargo > MaxWeight)
        {
            throw new OverfillException("Too much weight");
        }
        containers.Add(container);
    }

    public void AddContainers(List<Container> containerList)
    {
        foreach (var container in containerList)
        {
            AddContainer(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        containers.Remove(container);
    }

    public void ReplaceContainer(int containerId, Container newContainer)
    {
        var container = containers.FirstOrDefault(c => c.Id == containerId);
        if (container != null)
        {
            RemoveContainer(container);
            AddContainer(newContainer);
        }
    }

    public void TransferContainer(ContainerShip targetShip, Container container)
    {
        RemoveContainer(container);
        targetShip.AddContainer(container);
    }

    public void PrintContainerInfo(int containerId)
    {
        var container = containers.FirstOrDefault(c => c.Id == containerId);
        if (container != null)
        {
            Console.WriteLine($"Container ID: {container.Id}, Type: {container.Type}, Weight: {container.WeightOfCargo}");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Max Containers: {MaxContainers}, Max Weight: {MaxWeight}, Max Speed: {MaxSpeed}");
        Console.WriteLine("Containers on board:");
        foreach (var container in containers)
        {
            Console.WriteLine($"Container ID: {container.Id}, Type: {container.Type}, Weight: {container.WeightOfCargo}");
        }
    }
}