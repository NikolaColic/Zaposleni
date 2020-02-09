using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaposleniMVC.Models;

namespace ZaposleniApip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {



        private readonly ApplicationDbContext _db;


        public ValuesController(ApplicationDbContext db)
        {
            _db = db;
        }



        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Zaposleni>> Get()
        {
            var zaposleni = _db.Zaposleni.Include((z)=> z.Kompanija).ToList();
            return zaposleni;
        }
       




        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Zaposleni> Get(int id)
        {
           var zaposleni = _db.Zaposleni.Include((z) => z.Kompanija).SingleOrDefault((z) => z.OsobaID == id);
          // var zaposleni = _db.Zaposleni.Include((z) => z.Kompanija).SingleOrDefault((z) => z.Ime.Contains(id));
            if (zaposleni is null)
            {
                return NoContent();
            }
            return zaposleni;
        }


        


        //POST api/values
        [HttpPost]
        public ActionResult<IEnumerable<Zaposleni>> Post([FromBody] string value)
        {
            var zaposleni = _db.Zaposleni.Include((z) => z.Kompanija).Where((z) => z.Ime.Contains(value)).ToList();
            if (zaposleni.Count() == 0)
            {
                return NoContent();
            }
            return zaposleni;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Zaposleni zaposleni)
        {
            if (id != zaposleni.OsobaID)
            {
                return BadRequest();
            }

            _db.Entry(zaposleni).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var zaposleni = _db.Zaposleni.Include((z) => z.Kompanija).SingleOrDefault((z) => z.OsobaID == id);
            if (zaposleni is null) return NotFound();
            _db.Zaposleni.Remove(zaposleni);
            _db.SaveChanges();
            return new JsonResult("Uspesno");
        }
    }
}
