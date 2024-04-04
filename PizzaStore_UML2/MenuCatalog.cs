using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore_UML2
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
        }

        public void Delete(Pizza p)
        {
            _pizzas.Remove(p);
        }

        public void PrintMenu()
        {
            foreach (Pizza p in _pizzas)
            {
                Console.WriteLine(p);
            }

        }

        public List<Pizza> GetMenu()
        {
            return _pizzas;
        }

        public bool UpdatePizza(int pizzaNumberToUpdate, string newName, double newPrice)
        {
            foreach (Pizza pizza in _pizzas)
            {
                if (pizza.Number == pizzaNumberToUpdate)
                {
                    pizza.Name = newName;
                    pizza.Price = newPrice;
                    return true;
                }
            }
            return false;
        }
        public Pizza SearchPizza(int pizzaNumber)
        {
            foreach (Pizza pizza in _pizzas)
            {
                if (pizza.Number == pizzaNumber)
                {
                    return pizza;
                }
            }
            return null; 
        }
    }

}
