internal class Program
{
    private static void Main(string[] args)
    {
        Ipad ipad = new Ipad("ipad mini", "Apple");
        GalaxyTab galaxyTab = new GalaxyTab("Galaxy Tab", "Samsung");

        ipad.Accept(new WifiVisitor());
        galaxyTab.Accept(new WifiVisitor());

        ipad.Accept(new ThreeGVisitor());
        galaxyTab.Accept(new WifiVisitor());

        //We can make our class executable with new methods without changing the class by writing
        //other visitor classes like this one.


    }
}

abstract class Tablet
{
    private string model;
    private string brand;

    protected Tablet(string model, string brand)
    {
        this.model = model;
        this.brand = brand;
    }

    public string getModel()
    {
        return model;
    }

    public void setModel(string model)
    {
        this.model = model;
    }

    public string getBrand() { return brand; }
    public void setBrand(string brand) { this.brand = brand; }

    public abstract void Accept(IVisitor visitor);
}

class Ipad : Tablet
{
    public Ipad(string model, string brand) : base(model, brand)
    {
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.visit(this);
    }
}


class GalaxyTab : Tablet
{
    public GalaxyTab(string model, string brand) : base(model, brand)
    {
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.visit(this);
    }
}

interface IVisitor
{
    void visit(GalaxyTab tablet);
    void visit(Ipad tablet);
    void visit(object nonTablet);
}

class WifiVisitor : IVisitor
{
    public void visit(GalaxyTab tablet)
    {
        Console.WriteLine("GalaxyTab does not have wifi option.");
    }

    public void visit(Ipad tablet)
    {
        Console.WriteLine("Ipad wifi has open");
    }

    public void visit(object nonTablet)
    {
        Console.WriteLine("tablet not recognized");
    }
}
class ThreeGVisitor : IVisitor
{
    public void visit(Ipad tablet)
    {
        Console.WriteLine("Ipad does not have 3g option.");
    }

    public void visit(GalaxyTab tablet)
    {
        Console.WriteLine("GalaxyTab 3g has open");
    }

    public void visit(object nonTablet)
    {
        Console.WriteLine("tablet not recognized");
    }

}

