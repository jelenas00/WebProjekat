using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using System.Collections.Generic;

namespace AutoSalon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomobilController: ControllerBase
    {
        public AutoSalonContextKlasa Context { get; set; }
        
        public AutomobilController(AutoSalonContextKlasa context)
        {
            Context= context;
        }

        [Route("PrikaziAutomobile/{id}")]
        [HttpGet]
        public async Task<ActionResult>  PrikaziAutomobile(int id)
        {
            if(id<1)
            {
                return BadRequest("Nevalidan id!");
            }
            var automobili=await Context.Automobili.Where(a=>a.AutoPartnerID==id).ToListAsync();
            if(automobili==null)
            {
                return BadRequest("Nisu pronadjeni automobili!");
            }
            try{
                
                return Ok(automobili);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}