using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.interfaces
{
    internal interface ICategoryInterface
    {
        //GETALL
        IEnumerable<Categories> GetAllCategories();
        //GETBYID
        Categories GetCategory(int id);
        //ADD
        int AddCategory(Categories Category);
        //UPDATE
        int UpdateCategory(Categories Category);
        //DELETE
        int DeleteCategory(int id);
    }
}
