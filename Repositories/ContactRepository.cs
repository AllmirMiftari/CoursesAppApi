using OnlineCoursesApi.Data;
using OnlineCoursesApi.Interfaces;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Repositories
{
    public class ContactRepository : IContactRepository
    {

          private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Contact> SaveMessageAsync(Contact contact)
        {
        
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact;
        
        }
    }
}