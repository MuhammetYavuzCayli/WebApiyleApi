using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiyleApi.Classes;
using WebApiyleApi.Models;

namespace WebApiyleApi.Services
{
    interface Ib_service :IRepoDesign<Book>
    {
        object GetWithDetail(int id);
    }
}
