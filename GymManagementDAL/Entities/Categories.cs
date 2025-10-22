using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    internal class Categories : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Sessions> Sessions { get; set; }
    }
}
