using GymManagementBLL.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Business_Interfaces.Interfaces
{
    internal interface IMemberService
    {
        IEnumerable<MembersViewModel> GetAllMembers();
    }
}
