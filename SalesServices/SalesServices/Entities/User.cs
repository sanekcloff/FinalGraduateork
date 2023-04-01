using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesServices.Entities
{
    public class User
    {
        public User()
        {
            UserProducts = new HashSet<UserProduct>();
            UserServices= new HashSet<UserSvc>();
            FavoriteUserProducts= new HashSet<FavoriteUserProduct>();
        }

        public int ID { get; set; }

        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int RoleId { get;set; }

        public Role Role { get; set; } = null!;
        public UserProfile UserProfile { get; set; } = null!;

        public ICollection<UserProduct> UserProducts { get; set; } = null!;
        public ICollection<UserSvc> UserServices { get; set; } = null!;
        public ICollection<FavoriteUserProduct> FavoriteUserProducts { get; set; } = null!;

        [NotMapped]
        public string FullData { get => $"Логин: {Login}; Пароль: {Password};"; }
    }
}