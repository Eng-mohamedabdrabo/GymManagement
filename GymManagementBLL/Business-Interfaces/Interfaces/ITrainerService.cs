using GymManagementBLL.View_Models.Trainer_View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Business_Interfaces.Interfaces
{
    internal interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();

        bool CreateTrainer(CreateTrainerViewModel createTrainer);

        TrainerViewModel? GetTrainerDetails(int trainerId);

        CreateTrainerViewModel? GetTrainerToUpdate(int trainerId);

        bool UpdateTrainer(int trainerId , CreateTrainerViewModel createTrainer);

        bool DeleteTrainer(int trainerId);
    }
}
