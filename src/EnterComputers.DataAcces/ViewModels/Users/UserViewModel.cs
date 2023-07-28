using EnterComputers.Domain.Entities;
using EnterComputers.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterComputers.DataAcces.ViewModels.Users
{
    public class UserViewModel:Auditable
    {
        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string PassportSeriaNumber { get; set; } = String.Empty;

        public bool IsMale { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;

        public string Region { get; set; } = String.Empty;

        public string ImagePath { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public bool PhoneNumberConfirmed { get; set; }

        public DateTime LastActivity { get; set; }

        public IdentityRole IdentityRole { get; set; }
    }
}
