using BalanceApp.Domain.Entities;

namespace BalanceApp.Application.Dtos.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; }
        public string BirthDate { get; }
        public string Role { get; }
        public string LastUpdate { get; }
        public double Height { get; }
        public DateTime RegisterDate { get; }

        public UserDto(User user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Height = user.Height;
            BirthDate = user.BirthDate.ToString();
            Role = user.Role;
            LastUpdate = user.LastUpdate;
            RegisterDate = user.RegisterDate;
        }
    }
}
