﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KassenSystem.Models;
using KassenSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// Idea for registration for single Cash-Register-Frontend-Systems

namespace KassenSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ItemContext _context;



        public HomeController(ItemContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            
        }
        
        [HttpGet]
        public async Task<ActionResult<int>> GetRegister()
        {
            _logger.LogInformation("get register");
            Register reg = new Register();
             await _context.RegisterModels.AddAsync(reg);
            await _context.SaveChangesAsync();
            return reg.Id;
        }
        
    }
}

