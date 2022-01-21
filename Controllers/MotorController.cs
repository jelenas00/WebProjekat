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
    public class MotorController: ControllerBase
    {
        public AutoSalonContextKlasa Context { get; set; }

        public MotorController (AutoSalonContextKlasa context)
        {
            Context=context;
        }

        [Route("PrikaziMotore/{id}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziMotore(int id)
        {
            if(id<1)
            {
                return BadRequest("Nevalidan ID!");
            }
            var motori= await Context.Motori.Where(m=>m.MotoPartnerID==id).ToListAsync();
            if(motori==null)
            {
                return BadRequest("Nisu pronadjeni motori");
            }
            try{
                
                return Ok(motori);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}