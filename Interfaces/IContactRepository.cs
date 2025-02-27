using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> SaveMessageAsync(Contact contact);
    }
}