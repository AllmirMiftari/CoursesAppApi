using System.ComponentModel.DataAnnotations;


namespace OnlineCoursesApi.Models
{
    public class Course
    {
          [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [StringLength(50, ErrorMessage = "Duration cannot be longer than 50 characters.")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Invalid image URL format.")]
        public string Images { get; set; }
      
        [StringLength(100, ErrorMessage = "Instructor name cannot be longer than 100 characters.")]
        public string Instructor { get; set; }

        [StringLength(1000, ErrorMessage = "Course info cannot be longer than 1000 characters.")]
        public string CourseInfo { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Link is required.")]
        public string CourseLink { get; set; }

        public Category? Category { get; set; }

        public List<Registration> Registrations { get; set; } = new List<Registration>();

    }
}