﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Categories : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Sessions> Sessions { get; set; }
    }
}
