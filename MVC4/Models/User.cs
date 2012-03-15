using System;
using System.Security.Cryptography;
using System.Text;

namespace MVC4.Models
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }

        const string ConstantSalt = "fzk4as#df!d6o9&";
        protected string HashedPassword { get; private set; }

        private string _passwordSalt;

        private string PasswordSalt
        {
            get
            {
                return _passwordSalt ?? (_passwordSalt = Guid.NewGuid().ToString("N"));
            }
            set { _passwordSalt = value; }
        }

        public User SetPassword(string pwd)
        {
            HashedPassword = GetHashedPassword(pwd);
            return this;
        }


        private string GetHashedPassword(string pwd)
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(PasswordSalt + pwd + ConstantSalt));
                return Convert.ToBase64String(computedHash);
            }
        }
        
        public bool ValidatePassword(string maybePwd)
        {
            if (HashedPassword == null)
                return true;
            return HashedPassword == GetHashedPassword(maybePwd);
        }
    }
}