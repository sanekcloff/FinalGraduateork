using System;
using System.Collections.Generic;

namespace SalesServices.Entities
{
    public class User
    {
        public User()
        {
            UserProducts = new HashSet<UserProduct>();
            UserServices= new HashSet<UserService>();
            FavoriteUserProducts= new HashSet<FavoriteUserProduct>();
        }

        public int ID { get; set; }

        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int UserProfileId { get;set; }

        public Role Role { get; set; } = null!;
        public UserProfile UserProfile { get; set; } = null!;

        public ICollection<UserProduct> UserProducts { get; set; } = null!;
        public ICollection<UserService> UserServices { get; set; } = null!;
        public ICollection<FavoriteUserProduct> FavoriteUserProducts { get; set; } = null!;
    }
}