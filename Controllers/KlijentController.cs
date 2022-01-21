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
    public class KlijentController: ControllerBase
    {
        public AutoSalonContextKlasa Context { get; set; }
        public KlijentController(AutoSalonContextKlasa context)
        {
            Context=context;
        }

        [Route("DodajKlijenta")]
        [HttpPost]
        public async Task<ActionResult> DodajKlijenta([FromBody] Klijent klijent)
        {
            var klijenti= await Context.Klijenti.Where(k=>k.Email==klijent.Password).FirstOrDefaultAsync();
            if(klijenti!=null)
            {
                    return BadRequest("Vec postoji klijent sa to mejl adresom!");
            }
            if(klijent.Ime.Length>50 || string.IsNullOrWhiteSpace(klijent.Ime) )
            {
                return BadRequest("Pogresno ime");
            }
            if(klijent.Prezime.Length>50 || string.IsNullOrWhiteSpace(klijent.Prezime) )
            {
                return BadRequest("Pogresno prezime");
            }
            if(klijent.JMBG<0 || klijent.JMBG>999999999)
            {return BadRequest("Nevalidan JMBG");}
            if(klijent.BrojLicneKarte<0 || klijent.BrojLicneKarte>999999)
            {return BadRequest("Licna karta prazna je!");}
            if(klijent.Password.Length>15)
            {
                return BadRequest("Pass nij eodbar!");
            }

            try{
                
                Context.Klijenti.Add(klijent);
                await Context.SaveChangesAsync();
                return Ok(Context.Klijenti.ToArray());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("NadjiKlijenta/{mail}/{pass}")]
        [HttpGet]
        public async Task<ActionResult> NadjiKlijenta(string mail,string pass)
        {
            try{
                var klijenti= await Context.Klijenti.Where(k=>k.Email==mail).FirstOrDefaultAsync();
                if(klijenti!=null)
                {
                    if(klijenti.Password==pass)
                    {
                        return Ok(klijenti);
                    }
                    else{
                        return BadRequest("Pogresna lozinka!");
                    }
                }
                else{
                    return BadRequest("Klijent sa takvom meil adresom ne postoji!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [Route("ObrisiKlijenta/{mail}/{pass}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiKlijenta(string mail,string pass)
        {
            try{
                    var klijent= await Context.Klijenti.Where(k=>k.Email==mail).FirstOrDefaultAsync();
                    if(klijent==null)
                    {
                        return BadRequest("Pogresna meil adresa!");
                    }
                    if(klijent.Password==pass)
                    {
                        string ime= klijent.Ime;
                        string prezime=klijent.Prezime;
                        Context.Klijenti.Remove(klijent);
                        await Context.SaveChangesAsync();
                        return Ok($"Klijent {ime} {prezime} je uspeno obrisan.");
                    }
                    else{
                        return BadRequest("Pogresna lozinka!");
                    }
                    
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AzurirajKlijenta/{mail}/{pass}/{newPass}")]
        [HttpPut]
        public async Task<ActionResult> AzurirajKlijenta(string mail,string pass,string newPass)
        {
            
            try{
                var klijenti= await Context.Klijenti.Where(k=>k.Email==mail).FirstOrDefaultAsync();
                if(klijenti==null)
                {
                    return BadRequest("Neispravna mail adresa/Nema klijenta sa tom meil adresom!");
                }
               if(klijenti.Password!=pass)
                    {
                        return BadRequest("Neispravna lozinka!");
                    }
                else{
                    klijenti.Password=newPass;
                    await Context.SaveChangesAsync();
                    return Ok("Lozinka uspesno promenjena!");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
