using FM.DATA;
using Microsoft.EntityFrameworkCore;

namespace FM.REPOSITORIES
{
    public class FMContext : DbContext
    {
        public FMContext(DbContextOptions<FMContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mailing> Mailings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MailingPerson> MailingPersons { get; set; }
        public DbSet<HomeGroup> HomeGroups { get; set; }
        public DbSet<GroupSession> GroupSessions { get; set; }
    }
}
