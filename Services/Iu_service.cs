using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiyleApi.Classes;
using WebApiyleApi.Models;

namespace WebApiyleApi.Services
{
    interface Iu_service : IRepoDesign<User>
    {
        object GetWithDetail(int id);
    }
}
