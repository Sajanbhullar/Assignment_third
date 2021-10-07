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
    public class DetailsModel : PageModel
    {
        private readonly PersonalContext _context;

        public DetailsModel(PersonalContext context)
        {
            _context = context;
        }

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
    }
}
