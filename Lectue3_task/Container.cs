namespace Lectue3_task;

public abstract class Container
{
    public double mass;
    private int height; //cm
    protected double tareWeight; //kg
    protected double cargoWeight;
    private int depth;
    public String serealNumber;
    private static int count=1;
    protected double maxPayload; //kg
    protected SortedDictionary<String, double> payload; // name - mass
    // 
    // products with temperatures
    protected Dictionary<string, double> productTemperatures = new Dictionary<string, double>()
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
    

    public Container(double mass, int height, double tareWeight, int depth, double maxPayload, char type)
    {
       // serealNumber = "KON-" + Char.ToUpper(type) + "-" + $"{count}";
        serealNumber = "KON-" + "no type" + "-" + $"{count}";
        count += 1;
        this.mass = mass;
        this.height = height;
        this.tareWeight = tareWeight;
        this.depth = depth;
        this.maxPayload = maxPayload;
    }

    public virtual void emptyCargo()
    {
        payload.Clear();
        cargoWeight = 0.0;
        mass = tareWeight;
    }

    public virtual void addCargo(String name, double weight)
    {
        if (cargoWeight+weight < maxPayload)
        {
            payload.Add(name, weight);
            cargoWeight += weight;
            mass+=weight;
        }
        else
        {
            throw new InvalidOperationException("Bro, that would be too much. put it somewhere else");
        }
       
        
    }

    public  void setType(String type)
    {
        String[] tokens = serealNumber.Split("-");
        tokens[1] = type.ToUpper();
        serealNumber = tokens[0]+"-"+tokens[1]+"-"+tokens[2];
    }

    public override string ToString()
    {
        return $"Number: {serealNumber} Content: {payload}";
    }
}

class LContainer : Container , HazardNotifier
{
    bool isHazardous;
    public LContainer(double mass, int height, double tareWeight, int depth, double maxPayload, char type, bool isHazardous) : base(mass, height, tareWeight, depth, maxPayload, type)
    {
        setType("L");
        this.isHazardous = isHazardous;
        // licquid
        
    }

    public void IHazardNotifier(String serealNumber)
    {
        Console.WriteLine("yo, this is so hazrdus and dangerous man. Container: "+serealNumber);
    }
    

    public override void addCargo(String name, double weight)
    {
        if (isHazardous)
        {
            if (cargoWeight+weight < maxPayload/2)
            {
                payload.Add(name, weight);
                cargoWeight += weight;
                mass+=weight;
            }
            else
            {
                IHazardNotifier(serealNumber);
            }
        }
        else
        {
            if (cargoWeight+weight < maxPayload*0.9)
            {
                payload.Add(name, weight);
                cargoWeight += weight;
                mass+=weight;
            }
            else
            {
                IHazardNotifier(serealNumber);
            }
        }
    }
    
}
class GContainer : Container , HazardNotifier
{
    public GContainer(double mass, int height, double tareWeight, int depth, double maxPayload, char type) : base(mass, height, tareWeight, depth, maxPayload, type)
    {
        setType("G");
        // gas
    }
    
    public void IHazardNotifier(String serealNumber)
    {
        Console.WriteLine("yo, this is so hazrdus and dangerous man. Container: "+serealNumber);
    }

    public override void emptyCargo()
    {
        payload.Clear();
        cargoWeight = 0.05*cargoWeight;
        mass = tareWeight+ cargoWeight;
    }
    
}
class CContainer : Container
{
    private string productName;
    private double temperature;
    public CContainer(double mass, int height, double tareWeight, int depth, double maxPayload, char type, string productName, double temperature) : base(mass, height, tareWeight, depth, maxPayload, type)
    {
        this.productName = productName;
        this.temperature = temperature;
        setType("C");
        // refirigiratered
    }

    public override void addCargo(String name, double weight)
    {
        double p_temperature=0;
        foreach (var item in productTemperatures)
        {
            if (item.Key == name)
            {
                p_temperature = item.Value;
                break;
            }
        }
        
        if (cargoWeight+weight < maxPayload && name == productName && p_temperature >= temperature)
        {
            payload.Add(name, weight);
            cargoWeight += weight;
            mass+=weight;
        }
        else
        {
            throw new InvalidOperationException("Bro, that would be too much. put it somewhere else or temperature or product name");
        }
       
        
    }
}
