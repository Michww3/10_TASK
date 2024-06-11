class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("Same client code can work with different subclasses:");
        ClientCode(new ConcreteClass1());
        Console.Write("\n");

        Console.WriteLine("Same client code can work with different subclasses:");
        ClientCode(new ConcreteClass2());
    }
    public static void ClientCode(AbstractClass abstractClass)
    {
        abstractClass.TemplateMethod();
    }
}


public abstract class AbstractClass
{
    // Шаблонный метод определяет скелет алгоритма.
    public void TemplateMethod()
    {
        BaseOperation1();
        RequiredOperations1();
        BaseOperation2();
        Hook1();
        RequiredOperation2();
        BaseOperation3();
        Hook2();
    }

    // implemented oper
    protected void BaseOperation1()
    {
        Console.WriteLine("AbstractClass says: I am doing the bulk of the work");
    }

    protected void BaseOperation2()
    {
        Console.WriteLine("AbstractClass says: But I let subclasses override some operations");
    }

    protected void BaseOperation3()
    {
        Console.WriteLine("AbstractClass says: But I am doing the bulk of the work anyway");
    }

    protected abstract void RequiredOperations1();
    protected abstract void RequiredOperation2();


    protected virtual void Hook1() { }
    protected virtual void Hook2() { }
}

class ConcreteClass1 : AbstractClass
{
    protected override void RequiredOperations1()
    {
        Console.WriteLine("ConcreteClass1 says: RequiredOperations1 implemented");
    }

    protected override void RequiredOperation2()
    {
        Console.WriteLine("ConcreteClass1 says: RequiredOperations2 implemented");
    }
}

class ConcreteClass2 : AbstractClass
{
    protected override void RequiredOperations1()
    {
        Console.WriteLine("ConcreteClass2 says: RequiredOperations1 implemented");
    }

    protected override void RequiredOperation2()
    {
        Console.WriteLine("ConcreteClass2 says: RequiredOperations2 implemented");
    }

    protected override void Hook1()
    {
        Console.WriteLine("ConcreteClass2 says: Overridden Hook1");
    }
}
