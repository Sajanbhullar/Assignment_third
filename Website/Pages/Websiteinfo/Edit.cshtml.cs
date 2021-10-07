using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.Pages_Websiteinfo
{
    public class EditModel : PageModel
    {
        private readonly PersonalContext _context;

        public EditModel(PersonalContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Websiteinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteinfoExists(Websiteinfo.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WebsiteinfoExists(int id)
        {
            return _context.Websiteinfo.Any(e => e.ID == id);
        }
    }
}
