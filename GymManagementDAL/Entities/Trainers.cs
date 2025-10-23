using GymManagementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Trainers : GymUsers
    {
        //HireDate => CreatedAt
        public Specialist Specialist { get; set; }

        #region RelationShips
        #region Relation With Sessions
        public ICollection<Sessions> Sessions { get; set; }
        #endregion
        #endregion
    }
}
