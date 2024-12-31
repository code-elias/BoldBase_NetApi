namespace RepositoryNetAPI.Models.AppModels
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstNames { get; set; } = "Test";
        public string LastName { get; set; } = "Test";
        public string Email { get; set; } = "test@test.com";
        public string PhoneNumber { get; set; } = "0123 456789"; 


        public User GetUserModel()
        {
            return new User()
            {
                UserName = UserName,
                PasswordHash = Password,
                FirstNames = FirstNames,
                LastName = LastName,
                Notes = "Test User"
            };
        }
    }
}
