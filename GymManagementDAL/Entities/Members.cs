using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    internal class Members : GymUsers
    {
        //CreatedAt(in BaseEntity) => JoinDate (later)

        public string? Photo { get; set; }

        #region RelationShips
        #region Relation with HealthRecord 1:1
        public HealthRecords HealthRecords { get; set; }
        #endregion

        #region Relation With Membership 1:M Which represents Plan : Member (M:M)
        public ICollection<Memberships> Memberships { get; set; }
        #endregion

        #region Relation With MemberSessions 1:M Which represents Session : Member (M:M)
        public ICollection<MemberSessions> MemberSessions { get; set; }
        #endregion
        #endregion
    }
}
