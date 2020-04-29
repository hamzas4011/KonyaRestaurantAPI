using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using KonyaRestaurantAPI.Models;
using Microsoft.AspNetCore.Hosting;


// kanskje det ikke trengs de to usingene her, men vi venter med å ta vekk
/*
using Microsoft.AspNetCore.Http;
using System.IO;
*/


namespace KonyaRestaurantAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class KonyaRestauranController : ControllerBase{

        private readonly KonyaRestaurantContext _context;
        private readonly IWebHostEnvironment _hosting;

        public KonyaRestauranController(KonyaRestaurantContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

       //Httpget for default, altså for matrett

         [HttpGet]
        public async Task<IEnumerable<Matrett>> Get(){
            List<Matrett> matrettList = await _context.Matrett.ToListAsync();
            return matrettList;
        }

 
       //Http get for drikke tabell
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Drikke>> GetDrikke(){
            List<Drikke> drikkeList = await _context.Drikke.ToListAsync();
            return drikkeList;
        }
        
         //Http get for dessert tabell
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Dessert>> GetDessert(){
            List<Dessert> dessertList = await _context.Dessert.ToListAsync();
            return dessertList;
        }
      
        
    }
}

