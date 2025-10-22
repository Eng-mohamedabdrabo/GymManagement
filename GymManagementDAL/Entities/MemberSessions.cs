using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    internal class MemberSessions : BaseEntity
    {
        public bool IsAttended { get; set; }

        #region Relations

        #region Relation With Member
        public int MembersId { get; set; }

        public Members Members { get; set; }
        #endregion

        #region Relation With Sessions
        public int SessionsId { get; set; }

        public Sessions Sessions { get; set; }
        #endregion
        #endregion
    }
}
