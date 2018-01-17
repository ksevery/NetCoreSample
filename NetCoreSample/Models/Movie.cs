using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSample.Models
{
    public class Movie
    {
        public Movie()
        {
            this.DirectorsMovies = new HashSet<DirectorsMovies>();
        }

        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DirectorsMovies> DirectorsMovies { get; set; }
    }
}
