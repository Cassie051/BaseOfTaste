using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base_of_Taste.Concreate;
using BazaSmakuAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Base_of_Taste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepiesController : ControllerBase
    {
        private DBRepository _repo = new DBRepository();
        // GET: api/<RecepiesController>
        /*HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         // GET api/<RecepiesController>/5
         [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }

         // POST api/<RecepiesController>
         [HttpPost]
         public void Post([FromBody] string value)
         {
         }

         // PUT api/<RecepiesController>/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE api/<RecepiesController>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/

        [HttpPost("[action]")]
        public IActionResult AddAlergen([FromBody] Alergen alergen)
        {
            try
            {
                return new JsonResult(_repo.AddAlergen(alergen));
            }
            catch(Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult AddDieta([FromBody] Dieta dieta)
        {
            try
            {
                return new JsonResult(_repo.AddDieta(dieta));
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult AddJednostka([FromBody] Jednostka jednostka)
        {
            try
            {
                return new JsonResult(_repo.AddJednostka(jednostka));
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult AddPrzepis([FromBody] ViewPrzepis vprzepis)
        {
            try
            {
                return new JsonResult(_repo.AddPrzepis(vprzepis));
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult AddSkladnik([FromBody] ViewSkladniki vskladnik)
        {
            try
            {
                return new JsonResult(_repo.AddSkladnik(vskladnik));
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult AddTypDania([FromBody] TypDania typDania)
        {
            try
            {
                return new JsonResult(_repo.AddTypDania(typDania));
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult AddWartoscOdzywcza([FromBody] WartoscOdzywcza wartoscOdzywcza)
        {
            try
            {
                return new JsonResult(_repo.AddWartoscOdrzywcza(wartoscOdzywcza));
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpGet("[action]")]
        public IActionResult GetAlergeny()
        {
            try
            {
                return new JsonResult(_repo.GetAlergeny());
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpGet("[action]")]
        public IActionResult GetDiety()
        {
            try
            {
                return new JsonResult(_repo.GetDiety());
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpGet("[action]")]
        public IActionResult GetJednostki()
        {
            try
            {
                return new JsonResult(_repo.GetJednostki());
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpGet("[action]")]
        public IActionResult GetPrzepisy()
        {
            try
            {
                return new JsonResult(_repo.GetPrzepisy());
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpGet("[action]")]
        public IActionResult GetSkladniki()
        {
            try
            {
                return new JsonResult(_repo.GetSkladniki());
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpGet("[action]")]
        public IActionResult GetTypyDan()
        {
            try
            {
                return new JsonResult(_repo.GetTypyDania());
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteAlergen([FromBody] int id)
        {
            try
            {
                _repo.UsunAlergen(id);
                return Ok();
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteDieta([FromBody] int id)
        {
            try
            {
                _repo.UsunDieta(id);
                return Ok();
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteOpis([FromBody] int id)
        {
            try
            {
                _repo.UsunOpis(id);
                return Ok();
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult DeletePrzepis([FromBody] int id)
        {
            try
            {
                _repo.UsunPrzepis(id);
                return Ok();
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteSkladnik([FromBody] int id)
        {
            try
            {
                _repo.UsunSkladnik(id);
                return Ok();
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteTypDania([FromBody] int id)
        {
            try
            {
                _repo.UsunTypDania(id);
                return Ok();
            }
            catch (Exception e)
            { return BadRequest(e); }
        }

        [HttpPost("[action]")]
        public IActionResult DeleteWartoscOdzywcza([FromBody] int id)
        {
            try
            {
                _repo.UsunWartoscOdrzywcza(id);
                return Ok();
            }
            catch (Exception e)
            { return BadRequest(e); }
        }






    }
}
