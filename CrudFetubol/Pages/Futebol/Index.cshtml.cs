using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudFutebol.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudFutebol.Pages.Futebol
{
    public class IndexModel : PageModel
    {
        IJogadorRepository _jogadorRepository;

        public IndexModel(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        [BindProperty]
        public List<Entities.Jogador> listaJogadores { get; set; }

        [BindProperty]
        public Entities.Jogador jogador { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            listaJogadores = _jogadorRepository.GetJogadores();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _jogadorRepository.Delete(id);
                if (count > 0)
                {
                    Message = "Jogador removido com sucesso!";
                    return RedirectToPage("/Futebol/Index");
                }
            }
            return Page();
        }
    }
}
