using System;

namespace MyWebAPI.Data.Responses
{
    public class UsersResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
