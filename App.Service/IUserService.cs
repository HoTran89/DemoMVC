using System.Collections.Generic;

namespace App.Service
{
    public interface IUserService
    {
        IList<UserListItemSummary> GetAll();
        CreateUserResponse CreateUser(CreateUserRequest createUserRequest);
    }
}
