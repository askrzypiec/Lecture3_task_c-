using Lectue3_task;

class Program
{
    public static void Main(string[] args)
    {
        CargoShip cs1 = new CargoShip("independece", 100, 4, 4000);
        CargoShip cs2 = new CargoShip("devotion", 100, 10, 1000);

        Container c1 = new CContainer(100, 100, 50, 100, 100, 'g', "Sausages", 5);
        Container c2 = new LContainer(100, 100, 50, 100, 200, 'g', true);
        Container c3 = new GContainer(100, 100, 50, 100, 300, 'g');
        Container c4 = new CContainer(100, 100, 50, 100, 400, 'g', "Meat", 9);
        
        
        Console.WriteLine("Hello, prograam");
        cs1.addContainer(c1);
        cs1.addContainer(c2);
        cs1.addContainer(c3);
        cs1.addContainer(c4);
        
        Console.WriteLine(cs1);
        
        cs1.rmContainer(c2);
        
        CargoShip.transferContainers(cs1, cs2,c1);
        Console.WriteLine(cs1);
        Console.WriteLine(cs2);
        
    }
}