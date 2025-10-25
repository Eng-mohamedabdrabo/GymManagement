using GymManagementBLL.Business_Interfaces.Interfaces;
using GymManagementBLL.View_Models;
using GymManagementBLL.View_Models.Members_View_Models;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.implementation;
using GymManagementDAL.Reposetories.interfaces;
using GymManagementDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Business_Interfaces.Implementation
{
    public class MembersService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MembersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MembersViewModel> GetAllMembers()
        {
            var memberRepo = _unitOfWork.GetRepository<Members>();
            var members = memberRepo.GetAll();

            if (members == null || !members.Any())
                return []; //return Enumerable.Empty<MembersViewModel>();


            #region First way of manual mapping
            //var listOfMembersViewModel = new List<MembersViewModel>();

            //foreach (var member in members)
            //{
            //    var memberViewModel = new MembersViewModel
            //    {
            //        Id = member.Id,
            //        Name = member.Name,
            //        Email = member.Email,
            //        Photo = member.Photo,
            //        Phone = member.Phone,
            //        Gender = member.Gender.ToString(),
            //    };
            //    listOfMembersViewModel.Add(memberViewModel);
            //}
            //return listOfMembersViewModel; 
            #endregion

            #region Second Way Of Manual Mapping
            var membersViewModel = members.Select(M => new MembersViewModel
            {
                Id = M.Id,
                Name = M.Name,
                Phone = M.Phone,
                Photo = M.Photo,
                Email = M.Email,
                Gender = M.Gender.ToString(),
            });

            return membersViewModel;
            #endregion
        }

        public bool CreateMember(CreateMemberViewModel createMember)
        {
            var memberRepo = _unitOfWork.GetRepository<Members>();
           

            if (IsEmailExist(createMember.Email) || IsPhoneExist(createMember.Phone))
                return false;

            var member = new Members
            {
                Email = createMember.Email,
                Phone = createMember.Phone,
                Name = createMember.Name,
                DateOfBirth = createMember.DateOfBirth,
                Gender = createMember.Gender,
                Address = new Address
                {
                    BuildingNumber = createMember.BuildingNumber,
                    City = createMember.City,
                    Street = createMember.Street,
                },
                HealthRecords = new HealthRecords
                {
                    Height = createMember.HealthRecord.Height,
                    Weight = createMember.HealthRecord.Weight,
                    BloodType = createMember.HealthRecord.BloodType,
                }
            };

             memberRepo.Add(member) ;
            return _unitOfWork.SaveChanges() > 0;
        }

        public MemberToUpdateViewModel? GetMemberToUpdate(int memberId)
        {
            var member = _unitOfWork.GetRepository<Members>().GetById(memberId);

            if (member is null)
                return null;

            else
                return new MemberToUpdateViewModel
                {
                    Name = member.Name,
                    Photo = member.Photo,
                    Email = member.Email,
                    Phone = member.Phone,
                    BuildingNumber = member.Address.BuildingNumber,
                    City = member.Address.City,
                    Street = member.Address.Street,
                };
        }

        public bool UpdateMember(int memberId, MemberToUpdateViewModel memberToUpdate)
        {
            var memberRepo = _unitOfWork.GetRepository<Members>();

            if (IsEmailExist(memberToUpdate.Email) || IsPhoneExist(memberToUpdate.Phone))
                return false;

            var member = _unitOfWork.GetRepository<Members>().GetById(memberId);

            if (member is null) return false;

            member.Email = memberToUpdate.Email;
            member.Phone = memberToUpdate.Phone;
            member.Address.BuildingNumber = memberToUpdate.BuildingNumber;
            member.Address.City = memberToUpdate.City;
            member.Address.Street = memberToUpdate.Street;
            member.UpdatedAt = DateTime.Now;

            memberRepo.Update(member) ;
             return _unitOfWork.SaveChanges() > 0;
        }

        public bool DeleteMember(int memberId)
        {
            try
            {
                var member = _unitOfWork.GetRepository<Members>().GetById(memberId);
                if (member is null) return false;
                var MemberSessionIds = _unitOfWork.GetRepository<MemberSessions>()
                    .GetAll(X => X.MembersId == memberId)
                    .Select(X => X.SessionsId);

                var hasFutureSession = _unitOfWork.GetRepository<Sessions>()
                    .GetAll(X => MemberSessionIds.Contains(X.Id) && X.StartDate > DateTime.Now).Any();

                if (hasFutureSession)
                    return false;

                var memberShips =
                    _unitOfWork.GetRepository<Memberships>()
                    .GetAll(X => X.MembersId == memberId);

                if (memberShips.Any())
                {
                    foreach (var memberShip in memberShips)
                    {
                        _unitOfWork.GetRepository<Memberships>().Delete(memberShip);
                    }
                }

                 _unitOfWork.GetRepository<Members>().Delete(member) ;
                return _unitOfWork.SaveChanges() > 0;

            }
            catch (Exception)
            {

                return false;
            }


        }

        #region Helper Methods
        private bool IsEmailExist(string email) => _unitOfWork.GetRepository<Members>().GetAll(X => X.Email == email).Any();

        private bool IsPhoneExist(string phone) => _unitOfWork.GetRepository<Members>().GetAll(X => X.Phone == phone).Any();


        #endregion
    }
}
