using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSample.Models
{
    public class Director
    {
        public Director()
        {
            this.DirectorsMovies = new HashSet<DirectorsMovies>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DirectorsMovies> DirectorsMovies { get; set; }
    }
}
