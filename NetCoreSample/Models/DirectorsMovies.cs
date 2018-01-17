using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSample.Models
{
    public class DirectorsMovies
    {
        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
