using System.ComponentModel.DataAnnotations;


// models klasse for tabell
namespace KonyaRestaurantAPI.Models {

      public class Dessert {
          
          [Key]
         public int Id {get; set;}

         public string ImgName {get; set;}

        public string Name {get; set;}

        public string Description {get; set;}

        public int Price {get; set;}


      }




}