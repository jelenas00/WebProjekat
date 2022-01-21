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
    public class AutoPartnerController : ControllerBase
    {
        public AutoSalonContextKlasa Context;
        public AutoPartnerController(AutoSalonContextKlasa context)
        {
            Context=context;
        }

        [Route("PrikaziPartnere")]
        [HttpGet]
        public async Task<ActionResult> PrikaziPartnere()
        {
            try{
                /*var partneri= await Context.Partneri.ToListAsync();
                return Ok(partneri);*/
                return Ok(await Context.AutoPartneri.Select(p=>new {p.ID, p.Ime, p.GodinaOsnivanja,p.SedisteFirme }).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}