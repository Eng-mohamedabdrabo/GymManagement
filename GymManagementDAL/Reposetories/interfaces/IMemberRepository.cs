using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.interfaces
{
    internal interface IMemberRepository
    {
        //GETALL
        IEnumerable<Members> GetAllMembers();
        //GETBYID
        Members GetMember(int id);
        //ADD
        int AddMembers(Members member);
        //UPDATE
        int UpdateMembers(Members member);
        //DELETE
        int DeleteMember(int id);
    }
}
