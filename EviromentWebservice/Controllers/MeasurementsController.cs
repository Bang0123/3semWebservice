using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EviromentWebservice.Models;

namespace EviromentWebservice.Controllers
{
    public class MeasurementsController : ApiController
    {
        private Tempdb db = new Tempdb();

        // GET: api/Measurements
        public IQueryable<Measurement> GetMeasurements()
        {
            return db.Measurements;
        }

        // GET: api/Measurements/5
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> GetMeasurement(int id)
        {
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            return Ok(measurement);
        }

        // GET: api/Measurements/2011-02-17
        [HttpGet]
        [Route("{dt:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> GetMeasurementFromDate(DateTime dt)
        {
            var task = await Task.Run(() =>
            {
                var measurement = db.Measurements.Where(m => dt.Date > m.Tid.Date && dt.Date < m.Tid.Date);
                return measurement;
            });
            
            if (task == null || !task.Any())
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Measurements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeasurement(int id, Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measurement.ID)
            {
                return BadRequest();
            }

            db.Entry(measurement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Measurements
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> PostMeasurement(Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Measurements.Add(measurement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = measurement.ID }, measurement);
        }

        // DELETE: api/Measurements/5
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> DeleteMeasurement(int id)
        {
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            db.Measurements.Remove(measurement);
            await db.SaveChangesAsync();

            return Ok(measurement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeasurementExists(int id)
        {
            return db.Measurements.Count(e => e.ID == id) > 0;
        }
    }
}