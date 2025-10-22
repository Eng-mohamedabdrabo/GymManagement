using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.interfaces
{
    internal interface ITrainerRepository
    {
        //GETALL
        IEnumerable<Trainers> GetAllTrainers();
        //GETBYID
        Trainers GetTrainer(int id);
        //ADD
        int AddTrainer(Trainers trainer);
        //UPDATE
        int UpdateTrainer(Trainers trainer);
        //DELETE
        int DeleteTrainer(int id);
    }
}
