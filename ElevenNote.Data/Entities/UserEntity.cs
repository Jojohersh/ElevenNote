using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNote.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Username {get;set;} = null!;
        [Required]
        public string Password {get;set;} = null!;
        public string FirstName {get; set;}
        public string LastName {get;set;}
        [Required]
        public DateTime DateCreated {get;set;}
    }
}