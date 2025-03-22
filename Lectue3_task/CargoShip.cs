namespace Lectue3_task;

public class CargoShip
{
    private string name;
    List<Container> containers;
    private double currentWeight;
    private int maxspeed;
    private int maxContainersNumber;
    private double maxContainersWeight;
    private int id;
    private static int count = 0;

    public CargoShip(string name,int maxspeed,int maxContainersNumber,double maxContainersWeight)
    {
        id=count;
        count++;
        this.name = name;
        this.maxspeed = maxspeed;
        this.maxContainersNumber = maxContainersNumber;
        this.maxContainersWeight = maxContainersWeight;
        currentWeight = 0;
        containers = new List<Container>();
    }

    public void addContainer(Container a)
    {
        if (containers == null)
        {
            currentWeight += a.mass;
            containers.Add(a);
        }
        if (containers.Count+1 <= maxContainersNumber && maxContainersWeight >= currentWeight+a.mass)
        {
            currentWeight += a.mass;
            containers.Add(a);
        }
    }
    public void addContainers(List<Container> a)
    {
        double aMass = 0;
        foreach (Container a1 in a)
        {
            aMass += a1.mass;
        }
            
        if (containers.Count+a.Count <= maxContainersNumber && maxContainersWeight >= currentWeight+aMass)
        {
            currentWeight += aMass;
            foreach (Container a1 in containers)
            {
                containers.Add(a1);
            }
                
        }
    }

    public void rmContainer(Container a)
    {
        containers.Remove(a);
        currentWeight -= a.mass;
    }

    public void replaceContainer(Container a, int nr)
    {
        
        foreach (var c in containers)
        {
            string[] parts = c.serealNumber.Split('-');
            int number = int.Parse(parts[^1]);
            if (number == nr)
            {
                containers.Remove(c);
                containers.Add(a);
                break;
            }
        }

        
    }

    public static void transferContainers(CargoShip a, CargoShip b, Container c)
    {
        a.rmContainer(c);
        b.addContainer(c);
    }
    public override string ToString()
    {
        return $"Ship: {name}, Weight: {currentWeight}kg, Containers onboard: {
            string.Join(", ", containers)
        }";
    }
    
}
