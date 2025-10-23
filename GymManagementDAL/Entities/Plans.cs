using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Plans : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        #region RelationShips

        #region Relation With Membership 1:M Which represents Plan : Member (M:M)
        public ICollection<Memberships> Memberships { get; set; }
        #endregion 
        #endregion
    }
}
