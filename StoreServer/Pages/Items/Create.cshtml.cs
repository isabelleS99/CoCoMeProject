﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreServer.Data;
using StoreServer.Models;

namespace StoreServer.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly StoreServer.Data.StoreServerContext _context;

        public CreateModel(StoreServer.Data.StoreServerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ItemIdentifier ItemIdentifier { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_context.ItemIdentifier.ToList().Find(itemIdentifier => itemIdentifier.Name.ToLower() == ItemIdentifier.Name.ToLower()) == null)
            {
                _context.ItemIdentifier.Add(ItemIdentifier);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
