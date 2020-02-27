using ORP.Models;
using ORP.Models.Context;

namespace ORP.Business.Repositories
{
    public class TestRepository
    {
        public bool AddUser()
        {
            using (var context = new OrpContext())
            {
                context.Users.Add(new User
                {
                    Name = "Mads",
                    Clearance = new Clearance
                    {
                        Level = 1,
                        Name = "CIA"
                    },
                    Password = "password1"
                });
                context.SaveChanges();
            }

            return true;

        }
    }
}