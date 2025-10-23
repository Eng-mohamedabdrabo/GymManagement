using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class HealthRecords : BaseEntity
    {
        public Decimal Height { get; set; }
        public Decimal Weight { get; set; }

        public string BloodType { get; set; }
        public string? Note { get; set; }

        //UpdatedAt => LastUpdate
    }
}
