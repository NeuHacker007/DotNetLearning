using System;

namespace MyAOP
{
    public class UserProcessor : IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine($"User has already registered Name: {user.Name}; Password: {user.Password}");
        }
    }
}