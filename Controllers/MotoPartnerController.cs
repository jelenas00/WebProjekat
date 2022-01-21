using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AutoSalon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoPartnerController : ControllerBase
    {
        public AutoSalonContextKlasa Context;
        public MotoPartnerController(AutoSalonContextKlasa context)
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
                return Ok(await Context.MotoPartneri.Select(p=>new {p.ID, p.Ime, p.GodinaOsnivanja,p.SedisteFirme }).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("PrikaziPartnera/{ime}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziPartnere(string ime)
        {
            try{
                var partneri= await Context.MotoPartneri.Where(p=>p.Ime==ime).ToListAsync();
                return Ok(partneri);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}