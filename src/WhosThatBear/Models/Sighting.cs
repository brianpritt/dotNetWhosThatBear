using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WhosThatBear.Models
{
    [Table("Sightings")]
    public class Sighting
    {
        [Key]
        public int SightingId { get; set; }
        public string Date { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int SpeciesId { get; set; }
        public virtual Species Species { get; set; }
    
    }
}
