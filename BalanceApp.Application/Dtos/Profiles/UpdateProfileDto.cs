using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Application.Dtos.Profiles
{
    public record UpdateProfileDto
    {
        public double Height { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }

        public UpdateProfileDto()
        {
            Height = double.NaN;
            Firstname = string.Empty;
            Lastname = string.Empty;
            Gender = string.Empty;
        }

        public UpdateProfileDto(double height, string firstname, string lastname, string gender)
        {
            Height = height;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
        }
    }
}
