using GymManagementBLL.Business_Interfaces.Interfaces;
using GymManagementBLL.View_Models;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.implementation;
using GymManagementDAL.Reposetories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Business_Interfaces.Implementation
{
    public class MembersService : IMemberService
    {
        private readonly IGenericRepositoryInterface<Members> _genericRepository;
        public MembersService(IGenericRepositoryInterface<Members> genericRepository)
        {
            _genericRepository = genericRepository;
        }


        public IEnumerable<MembersViewModel> GetAllMembers()
        {
            var members = _genericRepository.GetAll();

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
            var ExistedEmail = _genericRepository.GetAll(X => X.Email == createMember.Email).Any();
            var ExistedPhone = _genericRepository.GetAll(X => X.Phone == createMember.Phone).Any();

            if (ExistedEmail || ExistedPhone)
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

            return _genericRepository.Add(member) > 0;
        }

    }
}
