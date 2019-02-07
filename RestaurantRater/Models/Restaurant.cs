using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Restaurant Rating")]
        [Range(1, 10, ErrorMessage ="Rating can be only between 1 and 10!")]
        public int Rating { get; set; }
    }

    public class RestaurantDbContext : DbContext 
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}