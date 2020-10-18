using BattleCards.Migrations;
using BattleCards.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        [HttpGet]
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            string userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }

        [HttpGet]
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (username.Length < 5 || username.Length > 20 || string.IsNullOrEmpty(username))
            {
                return this.Error("Invalid input. Username must be between 5 and 20 characters!");
            }

            if (password != confirmPassword)
            {
                return this.Error("Password and confirmation password did not match!");
            }

            if (password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password length! Must be between 6 and 20 characters!");
            }

            if (string.IsNullOrEmpty(email))
            {
                return this.Error("Invalid email address!");
            }

            if (!this.usersService.IsValidEmail(email))
            {
                return this.Error("Email already taken!");
            }

            if (!this.usersService.IsValidUser(username))
            {
                return this.Error("Username already taken!");
            }

            this.usersService.AddUser(username, email, password);

            return this.Redirect("/Users/Login");
        }

        [HttpGet("/Logout")]
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Log in first, smart ass!");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
