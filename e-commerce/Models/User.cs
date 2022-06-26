﻿using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName{ get; set; }
        public string LastName{ get; set; }

        public string Email { get; set; }

        public string Password{ get; set; }

    }
}
