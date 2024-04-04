using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore_UML2
{
    public class UserDialog
    {
        MenuCatalog _menuCatalog;
        public UserDialog(MenuCatalog menuCatalog)
        {
            _menuCatalog = menuCatalog;
        }

        Pizza GetNewPizza()
        {
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("Creating Pizza");
            Console.WriteLine();
            Console.Write("Enter name: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter pizza number: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
                throw;
            }

            return pizzaItem;
        }

        void DeletePizza()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Deleting Pizza");
                Console.WriteLine();
                Console.WriteLine("Enter the number of the pizza to delete:");
                string input = Console.ReadLine();
                int pizzaNumberToDelete = Int32.Parse(input);
                bool found = false;
                foreach (Pizza pizza in _menuCatalog.GetMenu())
                {
                    if (pizza.Number == pizzaNumberToDelete)
                    {
                        _menuCatalog.Delete(pizza);
                        Console.WriteLine($"Pizza with number {pizzaNumberToDelete} deleted.");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"Pizza with number {pizzaNumberToDelete} not found.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
            }
            Console.Write("Hit any key to continue");
            Console.ReadKey();
        }

        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("PIZZAMENU");
            Console.WriteLine();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
            }
            return -1;
        }

        void UpdatePizza()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Updating Pizza");
                Console.WriteLine();
                Console.WriteLine("Enter the number of the pizza to update:");
                int pizzaNumberToUpdate = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new name for the pizza:");
                string newName = Console.ReadLine();
                Console.WriteLine("Enter the new price for the pizza:");
                double newPrice = double.Parse(Console.ReadLine());

                bool updated = _menuCatalog.UpdatePizza(pizzaNumberToUpdate, newName, newPrice);
                if (updated)
                {
                    Console.WriteLine($"Pizza with number {pizzaNumberToUpdate} updated.");
                }
                else
                {
                    Console.WriteLine($"Pizza with number {pizzaNumberToUpdate} not found.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
            }
            Console.Write("Hit any key to continue");
            Console.ReadKey();
        }
        void SearchPizza()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the pizza to search:");
                int pizzaNumberToSearch = int.Parse(Console.ReadLine());

                Pizza searchedPizza = _menuCatalog.SearchPizza(pizzaNumberToSearch);
                if (searchedPizza != null)
                {
                    Console.WriteLine($"Pizza found: {searchedPizza}");
                }
                else
                {
                    Console.WriteLine($"Pizza with number {pizzaNumberToSearch} not found.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
            }
            Console.Write("Hit any key to continue");
            Console.ReadKey();
        }

        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Quit",
                "1. Create new pizza",
                "2. Delete pizza",
                "3. Update pizza",
                "4. Search for pizza",
                "5. Print menu",
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;
                    case 1:
                        try
                        {
                            Pizza pizza = GetNewPizza();
                            _menuCatalog.Create(pizza);
                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Enter the number of the pizza to delete:");
                        DeletePizza(); // Call the method to delete pizza
                        break;
                    case 3:
                        UpdatePizza();
                        break;
                    case 4:
                        SearchPizza();
                        break;
                    case 5:
                        _menuCatalog.PrintMenu();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                }
            }

        }
    }
}
