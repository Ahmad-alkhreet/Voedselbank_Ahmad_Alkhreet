using Microsoft.AspNetCore.Mvc.RazorPages;
using Voedselbank.Domain.Models;
using Voedselbank.BusinessLogic.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Voedselbank.Presentation.Pages.Food
{
    public class IndexModel : PageModel
    {
        private readonly FoodProductService _foodProductService;

        public IndexModel(FoodProductService foodProductService)
        {
            _foodProductService = foodProductService;
        }

        public IEnumerable<FoodProduct> FoodProducts { get; private set; }

        public async Task OnGetAsync()
        {
            FoodProducts = await _foodProductService.GetAllFoodProductsAsync();
        }
    }
}
