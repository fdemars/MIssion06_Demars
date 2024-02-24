using System.ComponentModel.DataAnnotations;

namespace Mission06_Demars.Models
{
    public class Category
    {
        [Key] //Make the CategoryId the key
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } //add a string value for the Category Name
    }
}
