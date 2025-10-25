using GymManagementBLL.Business_Interfaces.Interfaces;
using GymManagementBLL.View_Models.Trainer_View_Models;
using GymManagementDAL.Entities;
using GymManagementDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Business_Interfaces.Implementation
{
    internal class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var trainerRepo = _unitOfWork.GetRepository<Trainers>();
            var trainers = trainerRepo.GetAll();

            if (trainers is null || !trainers.Any())
                return [];

            return trainers.Select(T => new TrainerViewModel
            {
                Id = T.Id,
                Name = T.Name,
                Email = T.Email,
                Phone = T.Phone,
                Specialization = T.Specialist.ToString(),
            });
        }
        public bool CreateTrainer(CreateTrainerViewModel createTrainer)
        {
            var trainerRepo = _unitOfWork.GetRepository<Trainers>();
            if(IsEmailExist(createTrainer.Email) || IsPhoneExist(createTrainer.Phone) || createTrainer is null)
                return false;

            var trainer = new Trainers
            {
                Name = createTrainer.Name,
                Email = createTrainer.Email,
                Phone = createTrainer.Phone,
                Specialist = createTrainer.Specialization,
                DateOfBirth = createTrainer.DateOfBirth,
                Gender = createTrainer.Gender,
                Address = new Address
                {
                    Street = createTrainer.Street,
                    City = createTrainer.City,
                    BuildingNumber = createTrainer.BuildingNumber,
                },
            };

            try
            {
                trainerRepo.Add(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TrainerViewModel? GetTrainerDetails(int trainerId)
        {
            var trainerRepo = _unitOfWork.GetRepository<Trainers>();
            var trainer = trainerRepo.GetById(trainerId);

            if (trainer is null)
                return null;

            return new TrainerViewModel
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Specialization = trainer.Specialist.ToString(),
                DateOfBirth = trainer.DateOfBirth.ToShortDateString(),
                Gender = trainer.Gender.ToString(),
                Address = $"{trainer.Address.BuildingNumber}-{trainer.Address.Street}-{trainer.Address.City}",
            };
        }

        public CreateTrainerViewModel? GetTrainerToUpdate(int trainerId)
        {
            var trainerRepo = _unitOfWork.GetRepository<Trainers>();
            var trainer = trainerRepo.GetById(trainerId);

            if(trainer is null)
                return null;

            return new CreateTrainerViewModel
            {
                Name= trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Gender = trainer.Gender,
                BuildingNumber = trainer.Address.BuildingNumber,
                Street = trainer.Address.Street,
                City = trainer.Address.City,
                Specialization = trainer.Specialist,
            };
        }

        public bool UpdateTrainer(int trainerId, CreateTrainerViewModel trainerToUpdate)
        {
            var trainerRepo = _unitOfWork.GetRepository<Trainers>();
            var emailExistsForAnotherTrainer = trainerRepo
                .GetAll(X => X.Email == trainerToUpdate.Email && X.Id != trainerId).Any();
            var phoneExistsForAnotherTrainer = trainerRepo
                .GetAll(X => X.Phone == trainerToUpdate.Phone && X.Id != trainerId).Any();

            if(emailExistsForAnotherTrainer || phoneExistsForAnotherTrainer || trainerToUpdate is null)
                return false;

            var trainer = trainerRepo.GetById(trainerId);

            if(trainer is null) return false;

            trainer.Email = trainerToUpdate.Email;
            trainer.Phone = trainerToUpdate.Phone;
            trainer.Address.BuildingNumber = trainerToUpdate.BuildingNumber;
            trainer.Address.City = trainerToUpdate.City;
            trainer.Address.Street = trainerToUpdate.Street;

            trainer.UpdatedAt =DateTime.Now;
            try
            {
                trainerRepo.Update(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTrainer(int trainerId)
        {
            var trainerRepo = _unitOfWork.GetRepository<Trainers>();
            var trainer = trainerRepo.GetById(trainerId);

            if(trainer is null || HasFutureSessions(trainerId)) return false;

            try
            {
                trainerRepo.Delete(trainer);
                return _unitOfWork?.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #region Helper
        private bool IsEmailExist(string email) => _unitOfWork.GetRepository<Trainers>().GetAll(X => X.Email == email).Any();

        private bool IsPhoneExist(string phone) => _unitOfWork.GetRepository<Trainers>().GetAll(X => X.Phone == phone).Any();

        bool HasFutureSessions(int trainerId)
        {
            var futureSessionsStatus = _unitOfWork.GetRepository<Sessions>()
                 .GetAll(X => X.TrainersId == trainerId && X.StartDate>DateTime.Now ).Any();
            return futureSessionsStatus;
        }

        #endregion
    }
}
