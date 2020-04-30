using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using KonyaRestaurantAPI.Models;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Http;
using System.IO;


// nytt bibliotek for search
using System.Linq;


namespace KonyaRestaurantAPI.Controllers {

       [ApiController]
       [Route("[controller]")]
        public class KonyaRestaurantAdminController : ControllerBase {
    
           private readonly KonyaRestaurantContext _context;
           private readonly IWebHostEnvironment _hosting;
           public KonyaRestaurantAdminController(KonyaRestaurantContext context, IWebHostEnvironment hosting) {
                 _context = context;
                 _hosting = hosting;    
           }


           /*
           Http get metode for drikke tabell.
           Her måtte jeg bruke route action siden man kan ikke ha flere enn
           en default http get metode.

           */
  
         [HttpGet]
         [Route("[action]")]
        public async Task<IEnumerable<Drikke>> GetDrikke(){
            List<Drikke> drikkeList = await _context.Drikke.ToListAsync();
            return drikkeList;
        }
    
      
            //Http get metode for dessert tabell
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Dessert>> GetDessert(){
            List<Dessert> dessertList = await _context.Dessert.ToListAsync();
            return dessertList;
        }

        // Http get metode for matrett tabellen, altså default get.

        [HttpGet]
        public async Task<IEnumerable<Matrett>> Get(){
            List<Matrett> matrettList = await _context.Matrett.ToListAsync();
            return matrettList;
        }
    
         // henter id, for når man skal endre en matrett
    
        [HttpGet("{id}")]
         [Route("[action]/{id}")]
        public async Task<Matrett> GetId(int id){
            Matrett chosenMatrett = await _context.Matrett.FirstOrDefaultAsync( matrett => matrett.Id == id );
            return chosenMatrett;
        }
       
        // Samme greie som med get, bare at man søker etter navn

         [HttpGet("{name}")]
         [Route("[action]/{name}")]
        public async Task<IEnumerable<Matrett>> GetDishesAfterName(string name){
            List<Matrett> matrettList = await _context.Matrett
                .Where( 
                    matrett =>  matrett.Name.ToLower()
                    .Contains(name.ToLower()) 
                )
                .ToListAsync();

            return matrettList;
        } 
        
        
        // Http post metode for å legge til ny matrett
         [HttpPost]
        public async Task<Matrett> Post(Matrett newMatrett){
            _context.Matrett.Add(newMatrett);
            await _context.SaveChangesAsync();
            return newMatrett;
        }

        //Http metode for å endre matrett
        [HttpPut]
        public async Task<Matrett> Put(Matrett changeMatrett){
            _context.Update(changeMatrett);
            await _context.SaveChangesAsync();
            return changeMatrett;
        }
       
       // http metode for å slette matrett
         [HttpDelete("{id}")]
        public async Task<Matrett> Delete(int id){
            Matrett matrettToDelete = await _context.Matrett.FirstAsync( matrett => matrett.Id == id );
            _context.Matrett.Remove( matrettToDelete );
            await _context.SaveChangesAsync();
            return matrettToDelete;
        }


       //for å legge til bilde av en ny matrett
         [HttpPost]
        [Route("[action]")]
        public void UploadImage(IFormFile file){
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");
            using(var fileStream = new FileStream( absolutePath, FileMode.Create )){
                file.CopyTo( fileStream );
            }
        }

           
    }

 }


