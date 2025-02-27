using System.ComponentModel.DataAnnotations;


namespace OnlineCoursesApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}