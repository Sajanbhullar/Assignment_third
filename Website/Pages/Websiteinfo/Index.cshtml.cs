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
    public class IndexModel : PageModel
    {
        private readonly PersonalContext _context;

        public IndexModel(PersonalContext context)
        {
            _context = context;
        }

        public IList<Websiteinfo> Websiteinfo { get;set; }

        public async Task OnGetAsync()
        {
            Websiteinfo = await _context.Websiteinfo.ToListAsync();
        }
    }
}
