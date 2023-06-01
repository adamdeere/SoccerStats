using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Models;

namespace RazorPizza.Pages
{
    public class PizzaModel : PageModel
    {
        public List<PizzasModel> fakeDB = new List<PizzasModel>
        {
            new PizzasModel(){ImageTitle="Margerita", PizzaName="Margerita", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="Bolognese", PizzaName="Bolognese", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="Carbonara", PizzaName="Carbonara", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="Hawaiian", PizzaName="Hawaiian", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="MeatFeast", PizzaName="MeatFeast", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="Mushroom", PizzaName="Mushroom", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="Pepperoni", PizzaName="Pepperoni", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="Seafood", PizzaName="Seafood", Price=2, TomatoSauce=true, Cheese = true},
            new PizzasModel(){ImageTitle="Vegetarian", PizzaName="Vegetarian", Price=2, TomatoSauce=true, Cheese = true},
        };

        public void OnGet()
        {
        }
    }
}