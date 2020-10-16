using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        void AddUser(string username, string email, string password);

        bool IsValidEmail(string email);

        bool IsValidUser(string username);
    }
}
