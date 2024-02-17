using Microsoft.EntityFrameworkCore;
using MIssion06_Demars.Models;

namespace Mission06_Demars.Models
{
    public class MovieSubmissionContext : DbContext 
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base (options)  //build constructor to set up options and include base options
        {
        }

        public DbSet<Movie> Movies {  get; set; } // create table name in the databse called Movies
    }
}
