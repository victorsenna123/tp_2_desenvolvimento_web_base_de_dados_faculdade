using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Collections.Generic;

public class ViewDataModel : PageModel
{
    public List<string> FileContents { get; set; } = new List<string>();
    private readonly string FilePath;

    public ViewDataModel()
    {
        // Defina o caminho para o arquivo formData.txt dentro da pasta wwwroot/data
        FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "formData.txt");
    }

    public void OnGet()
    {
        // Verifica se o arquivo existe
        if (System.IO.File.Exists(FilePath))
        {
            // Lê todas as linhas do arquivo e as armazena na lista FileContents
            FileContents = new List<string>(System.IO.File.ReadAllLines(FilePath));
        }
    }
}
