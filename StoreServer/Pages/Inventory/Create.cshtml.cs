﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreServer.Data;
using StoreServer.Models;

namespace StoreServer.Pages.Inventory
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
        public InventoryItem InventoryItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InventoryItem.Add(InventoryItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
