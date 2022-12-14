using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNote.Data.Entities
{
    public class UserEntity
    {
        public int Id {get;set;}
        public string Email { get; set; } = null!;
        public string Username {get;set;} = null!;
        public string Password {get;set;} = null!;
        public string FirstName {get; set;} = null!;
        public string LastName {get;set;} = null!;
        public DateTime DateCreated {get;set;}
    }
}