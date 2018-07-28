using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiyleApi.Classes;
using WebApiyleApi.Models;

namespace WebApiyleApi.Services
{
    public class b_service : MyGenericRepo<Book, MyContext>, Ib_service
    {
        public object GetWithDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}