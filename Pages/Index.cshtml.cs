using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorSite.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string? Message { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    public void OnPostShowMessage()
    {
        Message = "👋 歡迎光臨 Razor 頁面！";
    }
}
