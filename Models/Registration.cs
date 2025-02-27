
namespace OnlineCoursesApi.Models
{
    public class Registration
    {
        public int CourseId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }
    }
}