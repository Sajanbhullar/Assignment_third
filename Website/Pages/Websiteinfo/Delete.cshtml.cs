using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.Pages_Websiteinfo
{
    public class DeleteModel : PageModel
    {
        private readonly PersonalContext _context;

        public DeleteModel(PersonalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Websiteinfo Websiteinfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Websiteinfo = await _context.Websiteinfo.FirstOrDefaultAsync(m => m.ID == id);

            if (Websiteinfo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Websiteinfo = await _context.Websiteinfo.FindAsync(id);

            if (Websiteinfo != null)
            {
                _context.Websiteinfo.Remove(Websiteinfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
