﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowDo1st
{
    public class UserService : IUserService
    {
        public bool CreateAccount(string name, string email, DateTime dateOfBirth, string location, long cardNumber)
        {
            var context = new CrowDoDbContext();

            if (IsValidEmail(email) == false)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (dateOfBirth.AddYears(18) > DateTime.Now)
            {
                return false;
            }

            if (cardNumber.ToString().Length != 16)
            {
                return false;
            }

            var usrexist = context.Set<User>().Where(c => c.CardNumber == cardNumber).Any();
            if (usrexist)
            {
                return false;
            }


            var userexist = context.Set<User>().Where(c => c.Email == email).Any();


            if (userexist)
            {
                return false;
            }
            var user = new User();
            user.Name = name;
            user.Email = email;
            user.DateOfBirth = dateOfBirth;
            user.DateOfRegister = DateTime.Now;
            user.Location = location;
            user.CardNumber = cardNumber;
            context.Add(user);
            context.SaveChanges();

            var rowsAffected = context.SaveChanges();
            if (rowsAffected < 1)
            {
                return false;
            }

            return true;
        }

        public bool DeleteAccount(string name, string email)
        {
            var context = new CrowDoDbContext();
            if (IsValidEmail(email) == false)
            {
                return false;
            }
            var user = context.Set<User>().SingleOrDefault(User => User.Email == email);
            if (user == null)
            {
                return false;
            }
            context.Remove(user);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected < 1)
            {
                return false;
            }
            return true;
        }

        public bool EditAccount(string name, string email, DateTime dateOfBirth, string location, long cardNumber)
        {
            var context = new CrowDoDbContext();

            if (IsValidEmail(email) == false)
            {
                return false;
            }
            var user = context.Set<User>().SingleOrDefault(User => User.Email == email);
            if (user == null)
            {
                return false;
            }
            user.Name = name;
            user.Email = email;
            user.DateOfBirth = dateOfBirth;
            user.DateOfRegister = DateTime.Now;
            user.Location = location;
            user.CardNumber = cardNumber;
            var rowsAffected = context.SaveChanges();
            if (rowsAffected < 1)
            {
                return false;
            }
            return true;
        }

        public bool IsValidEmail(string email)

        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            if (!email.Contains("@"))
            {
                return false; ;
            }
            return true;
        }

        



    }
}
