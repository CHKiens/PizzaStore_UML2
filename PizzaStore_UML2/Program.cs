namespace PizzaStore_UML2
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Test();
            Console.Write("Hit any key to continue with user dialog");
            Console.ReadKey();
            store.Run();
        }
    }
}