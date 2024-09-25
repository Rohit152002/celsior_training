﻿namespace UnderstandingLayeredStructure.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public User()
        {
            
        }
        public override string ToString()
        {
            return $"name : {Name}\nemail: {Email}";
        }
    }
}