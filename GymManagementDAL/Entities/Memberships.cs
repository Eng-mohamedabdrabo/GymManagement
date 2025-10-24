using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Memberships : BaseEntity
    {
        public DateTime EndDate { get; set; }

        public string Status
        {
            get
            {
                if (EndDate <= DateTime.Now)
                    return "Expired";
                else
                    return "Active";
            }
        }

        #region Relations
        #region Relation With Member 1 : M
        public int MembersId { get; set; }
        public Members Members { get; set; }
        #endregion

        #region Relation With Plans 1:M
        public int PlansId { get; set; }

        public Plans Plans { get; set; }
        #endregion
        #endregion
    }
}
