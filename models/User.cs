﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGenerator.models
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Mobile { get; set; }
        public string FavoriteAnimeName { get; set; }

        public User() { }

        public User(int id, string login, string password, int age, string mobile, string favoriteAnime)
        {
            Id = id;
            Login = login;
            Password = password;
            Age = age;
            Mobile = mobile;
            FavoriteAnimeName = favoriteAnime;
        }
    }
}
