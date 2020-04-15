using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using KonyaRestaurantAPI.Models;
using Microsoft.AspNetCore.Hosting;


namespace KonyaRestaurantAPI.Controllers {

       [ApiController]
       [Route("[controller]")]
        public class KonyaRestaurantController : ControllerBase {
    
           private readonly KonyaRestaurantContext _context;
           private readonly IWebHostEnvironment _hosting;
           public KonyaRestaurantController(KonyaRestaurantContext context, IWebHostEnvironment hosting) {
                 _context = context;
                 _hosting = hosting;    
           }

        [HttpGet]
        public async Task<IEnumerable<Matrett>> Get(){
            List<Matrett> matrettList = await _context.Matrett.ToListAsync();
            return matrettList;
        }

        [HttpGet("{id}")]
        public async Task<Matrett> Get(int id){
            Matrett chosenMatrett = await _context.Matrett.FirstOrDefaultAsync( matrett => matrett.Id == id );
            return chosenMatrett;
        }

         [HttpPost]
        public async Task<Matrett> Post(Matrett newMatrett){
            _context.Matrett.Add(newMatrett);
            await _context.SaveChangesAsync();
            return newMatrett;
        }

        [HttpPut]
        public async Task<Matrett> Put(Matrett changeMatrett){
            _context.Update(changeMatrett);
            await _context.SaveChangesAsync();
            return changeMatrett;
        }
       
         [HttpDelete("{id}")]
        public async Task<Matrett> Delete(int id){
            Matrett matrettToDelete = await _context.Matrett.FirstAsync( matrett => matrett.Id == id );
            _context.Matrett.Remove( matrettToDelete );
            await _context.SaveChangesAsync();
            return matrettToDelete;
        }

           
    }

 }


