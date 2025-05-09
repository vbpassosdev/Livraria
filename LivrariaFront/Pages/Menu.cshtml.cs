using LivrariaFront.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MenuModel : PageModel
{
    private readonly LivrariaService _livrariaService;

    public MenuModel(LivrariaService livrariaService)
    {
        _livrariaService = livrariaService;
    }

    public List<Livro> Livros { get; set; }

    public async Task OnGetAsync()
    {
        Livros = await _livrariaService.GetLivrosAsync();
    }
}