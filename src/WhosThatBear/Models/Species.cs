using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace WhosThatBear.Models
{
    [Table("Species")]
    public class Species
    {
        public Species()
        {
            this.Sightings = new HashSet<Sighting>();
        }
        [Key]
        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sighting> Sightings { get; set; }

    }
    
}
