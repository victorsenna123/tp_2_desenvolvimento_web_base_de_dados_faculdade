using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EX_4.Pages;

public class IndexModel : PageModel
{
    public List<string> Items { get; set; }

    public void OnGet()
    {
        Items = new List<string> { "Item 1", "Item 2", "Item 3" };
    }
}

