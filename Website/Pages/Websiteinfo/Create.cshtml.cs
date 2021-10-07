using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Website.Models;

namespace Website.Pages_Websiteinfo
{
    public class CreateModel : PageModel
    {
        private readonly PersonalContext _context;

        public CreateModel(PersonalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Websiteinfo Websiteinfo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Websiteinfo.Add(Websiteinfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
