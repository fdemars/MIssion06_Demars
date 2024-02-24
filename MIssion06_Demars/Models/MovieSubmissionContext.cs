using Microsoft.EntityFrameworkCore;
using MIssion06_Demars.Models;

namespace Mission06_Demars.Models
{
    public class MovieSubmissionContext : DbContext //Liaison from the app to the database
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base (options)  //build constructor to set up options and include base options
        {
        }

        public DbSet<Movie> Movies {  get; set; } // create table name in the database called Movies
        public DbSet<Category> Categories { get; set; } //make a table named Categories. This will be visible in the database
    }
}
