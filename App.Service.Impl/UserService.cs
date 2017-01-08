using App.Entity;
using App.Repository;
using AutoMapper;
using System.Collections.Generic;

namespace App.Service.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository<UserEntity> _userRepository;

        public UserService(IUserRepository<UserEntity> userRepository)
        {
            this._userRepository = userRepository;
        }
        public CreateUserResponse CreateUser(CreateUserRequest createUserRequest)
        {
            UserEntity userEntity = Mapper.Map<UserEntity>(createUserRequest);
            var createUserResponse = this._userRepository.Insert(userEntity);
            this._userRepository.SaveChanges();
            return null;
        }

        public IList<UserListItemSummary> GetAll()
        {
            var items = this._userRepository.GetAll();
            IList<UserListItemSummary> result = Mapper.Map<List<UserListItemSummary>>(items);
            return result;
        }
    }
}
