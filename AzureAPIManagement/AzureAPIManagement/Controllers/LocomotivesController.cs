using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureAPIManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPIManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocomotivesController : ControllerBase
    {
        #region Fields

        private static List<Locomotive> _Locomotives = new List<Locomotive>()
        {
            new Locomotive
            {
                ModelRange = "103",
                Type = "E",
                Length = 19500,
                ServiceWeight = 114,
                Vmax = 200
            },
            new Locomotive
            {
                ModelRange = "01",
                Type = "Dampf",
                Length = 23940,
                ServiceWeight = 109,
                Vmax = 120
            },
            new Locomotive
            {
                ModelRange = "V200",
                Type = "Diesel",
                Length = 18470,
                ServiceWeight = 80,
                Vmax = 140
            }
        };

        #endregion

        // GET: api/Locomotives
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Locomotive>), 200)]
        public async Task<ActionResult<IEnumerable<Locomotive>>> Get()
        {
            return Ok(new ActionResult<IEnumerable<Locomotive>>(_Locomotives));
        }

        // GET: api/Locomotives/V200
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Locomotive), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Locomotive>> Get(string id)
        {
            Locomotive locomotive = null;

            try
            {
                locomotive = _Locomotives.First(l => l.ModelRange == id);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

            return Ok(locomotive);
        }

        // POST: api/Locomotives
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Locomotives/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Locomotives/V200
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var itemToDelete = _Locomotives.First(l => l.ModelRange == id);
                _Locomotives.Remove(itemToDelete);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
