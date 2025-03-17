namespace Lectue3_task;

public abstract class Container
{
    protected double mass;
    private int height; //cm
    protected double tareWeight; //kg
    protected double cargoWeight;
    private int depth;
    protected String serealNumber;
    private int count=1;
    protected double maxPayload; //kg
    protected SortedDictionary<String, double> payload; // name - mass

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
    public CContainer(double mass, int height, double tareWeight, int depth, double maxPayload, char type) : base(mass, height, tareWeight, depth, maxPayload, type)
    {
        setType("C");
        // refirigiratered
    }
}


