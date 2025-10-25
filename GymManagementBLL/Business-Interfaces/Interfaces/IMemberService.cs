using GymManagementBLL.View_Models;
using GymManagementBLL.View_Models.Members_View_Models;
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

        bool CreateMember(CreateMemberViewModel createMember);

        MemberToUpdateViewModel? GetMemberToUpdate(int memberId);

        bool UpdateMember(int id ,MemberToUpdateViewModel memberToUpdate);

        bool DeleteMember(int id);
    }
}
