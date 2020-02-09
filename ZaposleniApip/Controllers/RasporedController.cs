using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaposleniMVC.Models;

namespace ZaposleniApip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RasporedController : ControllerBase
    {



        private readonly ApplicationDbContext _db;


        public RasporedController(ApplicationDbContext db)
        {
            _db = db;
        }




        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Raspored>> Get()
        {
            var raspored = _db.Raspored.Include((z) => z.Zaposleni).ToList();
            return raspored;
        }


        // GET api/values/5
        [HttpGet("{ime}")]
        public ActionResult<IEnumerable<Raspored>> Get(string ime)
        {
            
            var rasporedi = _db.Raspored.Include((z) => z.Zaposleni).Where((z) => z.Zaposleni.Ime.Contains(ime) ||
            z.Zaposleni.Prezime.Contains(ime) || z.Zaposleni.Adresa.Contains(ime));
            if (rasporedi.Count()==0)
            {
                return NoContent();
            }
            return rasporedi.ToList() ;
        }





        //POST api/values
        [HttpPost]
        public ActionResult<IEnumerable<Raspored>> Post([FromBody] string smena,[FromBody] DateTime datum )
        {
            var rasporedi = _db.Raspored.Include((z) => z.Zaposleni).Where((z) => z.Smena == smena && z.Datum.Date == datum.Date).ToList();
            if (rasporedi.Count() == 0)
            {
                return NoContent();
            }
            return rasporedi;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Raspored raspored)
        {
            if (id != raspored.RasporedID)
            {
                return BadRequest();
            }

            _db.Entry(raspored).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var raspored = _db.Raspored.Include((z) => z.Zaposleni).SingleOrDefault((z) => z.RasporedID == id);
            if (raspored is null) return NotFound();
            _db.Raspored.Remove(raspored);
            _db.SaveChanges();
            return new JsonResult("Uspesno");
        }
    }
}