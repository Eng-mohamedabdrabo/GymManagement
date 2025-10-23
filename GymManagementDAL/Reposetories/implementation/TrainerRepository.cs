using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.implementation
{
    internal class TrainerRepository : ITrainerRepository
    {
        private readonly GymDbContexts _dbContext;
        public TrainerRepository(GymDbContexts dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddTrainer(Trainers trainer)
        {
            _dbContext.Trainers.Add(trainer);
            return _dbContext.SaveChanges();
        }

        public int DeleteTrainer(int id)
        {
         var trainer =   _dbContext.Trainers.Find(id);
            if (trainer is null)
                return 0;
            _dbContext.Trainers.Remove(trainer);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Trainers> GetAllTrainers() => _dbContext.Trainers.ToList();


        public Trainers GetTrainer(int id) => _dbContext.Trainers.Find(id);



        public int UpdateTrainer(Trainers trainer)
        {
            _dbContext.Trainers.Update(trainer);
            return _dbContext.SaveChanges();
        }
    }
}
