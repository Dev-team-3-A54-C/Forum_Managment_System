﻿using ForumManagmentSystem.Infrastructure.Data.Models;
using ForumManagmentSystem.Infrastructure.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumManagmentSystem.Infrastructure.Repositories.Contracts
{
    public interface IUsersRepository
    {
        IList<UserDb> GetAll();
        IList<UserDb> FilterBy(UserQueryParameters usersParams);
        UserDb GetById(Guid id);
        UserDb GetByName(string name);
        UserDb Create(UserDb newUser); // Register
        UserDb Update(Guid id, UserDb user);
        bool Delete(Guid id);
        bool UserExists(string name);
        int Count();

    }
}
