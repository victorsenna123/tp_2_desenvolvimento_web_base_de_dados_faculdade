using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

public class FormPageModel : PageModel
{
    // Validação com Data Annotations
    [BindProperty]
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Message is required.")]
    [StringLength(500, ErrorMessage = "Message cannot be longer than 500 characters.")]
    public string Message { get; set; }

    public string FilePath { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            // Se houver erros de validação, retorna para a página com os erros
            return Page();
        }

        // Caminho onde os dados do formulário serão salvos no servidor
        FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "formData.txt");

        // Salvar os dados no arquivo (com append para não sobrescrever)
        using (StreamWriter writer = new StreamWriter(FilePath, append: true))
        {
            writer.WriteLine($"Name: {Name}");
            writer.WriteLine($"Email: {Email}");
            writer.WriteLine($"Message: {Message}");
            writer.WriteLine("--------------");
        }

        // Redireciona para uma página de sucesso ou exibe uma mensagem de sucesso
        TempData["SuccessMessage"] = "Form data saved successfully!";
        return RedirectToPage();
    }
}
