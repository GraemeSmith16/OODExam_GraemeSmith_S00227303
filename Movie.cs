using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OODExam_GraemeSmith_S00227303
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Cast { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }

    public class MovieData : DbContext
    {
        public MovieData() : base("OODExam_GraemeSmith") { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
