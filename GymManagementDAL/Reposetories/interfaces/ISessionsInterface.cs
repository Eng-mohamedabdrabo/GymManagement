using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.interfaces
{
    internal interface ISessionsInterface
    {
        //GETALL
        IEnumerable<Sessions> GetAllSessions();
        //GETBYID
        Sessions GetSession(int id);
        //ADD
        int AddSession(Sessions Session);
        //UPDATE
        int UpdateSession(Sessions Session);
        //DELETE
        int DeleteSession(int id);
    }
}
