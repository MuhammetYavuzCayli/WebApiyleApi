using WebApiyleApi.Classes;
using WebApiyleApi.Models;
using System.Data.Entity;
using System.Linq;
namespace WebApiyleApi.Services
{
    public class u_service : MyGenericRepo<User, MyContext>, Iu_service
    {
        public object GetWithDetail(int id)
        {
            var model = (from u in Contexts.User
                         join ubm in Contexts.UserBookRelation
                             on u.Id equals ubm.UserId
                         join b in Contexts.Book
                            on ubm.BookId equals b.Id
                         where u.Id == id
                         select new { u, b.Name }).ToList();
            return model;
        }
    }
}