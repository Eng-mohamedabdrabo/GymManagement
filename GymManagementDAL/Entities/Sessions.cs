using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Sessions : BaseEntity
    {
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        #region RealtionShips
        #region Relation With Categories
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }

        #endregion

        #region Relation With Trainers
        public int TrainersId { get; set; }
        public Trainers Trainers { get; set; }
        #endregion

        #region Relation With MemberSessions 1:M Which represents Session : Member (M:M)
        public ICollection<MemberSessions> MemberSessions { get; set; }
        #endregion
        #endregion

    }
}
