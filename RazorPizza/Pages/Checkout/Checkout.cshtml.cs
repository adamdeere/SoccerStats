using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Data;
using RazorPizza.Models;

namespace RazorPizza.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public CheckoutModel(ApplicationDbContext context)
        {
                _context = context;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom";
            }
            if (string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }
            PizzaOrder order = new PizzaOrder()
            {
                pizza_name = PizzaName,
                pizza_price = PizzaPrice,
            };
            _context.PizzaOrders.Add(order);
            _context.SaveChanges();
        }

        private readonly ApplicationDbContext _context;
        public string? PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string? ImageTitle { get; set; }
      
    }
}