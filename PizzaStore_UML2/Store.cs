using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore_UML2
{
    public class Store
    {
        MenuCatalog menuCatalog;
        MenuCatalog _testMenuCatalog;
        public int testPizzaNum = 1;
        public Store()
        {
            menuCatalog = new MenuCatalog();
        }
        public void Test()
        {
            
            _testMenuCatalog = new MenuCatalog();
            
            Console.Clear();
            Console.WriteLine();
            TestCreatePizza();
            TestPrintMenu();
            Console.WriteLine();
            TestUpdatePizza();
            TestPrintMenu();
            Console.WriteLine();
            TestDeletePizza();
            TestPrintMenu();
            Console.WriteLine();
            TestCreatePizza();
            TestPrintMenu();
            Console.WriteLine();
            TestSearchPizza();
        }

        private void TestCreatePizza()
        {
            Console.WriteLine("Testing Create Pizza:");
            
            Pizza pizza = new Pizza
            {
                Number = testPizzaNum,
                Name = "Margherita",
                Price = 10
            };

            _testMenuCatalog.Create(pizza);
            Console.WriteLine("Pizza created successfully.");
            testPizzaNum++;
        }

        private void TestDeletePizza()
        {
            Console.WriteLine("Testing Delete Pizza:");

            
            Pizza pizzaToDelete = new Pizza { Number = 1 };

            _testMenuCatalog.Delete(pizzaToDelete);
            Console.WriteLine("Pizza deleted successfully.");
        }

        private void TestUpdatePizza()
        {
            Console.WriteLine("Testing Update Pizza:");

            
            _testMenuCatalog.UpdatePizza(1, "Updated Pizza Name", 50);
            Console.WriteLine("Pizza updated successfully.");
        }

        private void TestPrintMenu()
        {
            Console.WriteLine("Testing Print Menu:");
            _testMenuCatalog.PrintMenu();
            Console.WriteLine("Menu printed successfully.");
        }

        private void TestSearchPizza()
        {
            Console.WriteLine("Testing Search Pizza:");

            
            int pizzaNumberToSearch = 1;
            Pizza foundPizza = _testMenuCatalog.SearchPizza(pizzaNumberToSearch);

            if (foundPizza != null)
                Console.WriteLine($"Pizza with number {pizzaNumberToSearch} found: {foundPizza}");
            else
                Console.WriteLine($"Pizza with number {pizzaNumberToSearch} not found.");
        }
        public void Run()
        {
            new UserDialog(menuCatalog).Run();
        }
    }
}
