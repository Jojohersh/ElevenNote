using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNote.Models.Note
{
    public class NoteDetail
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public DateTimeOffset CreatedUTC {get; set;}
        public DateTimeOffset? ModifiedUTC {get; set;}
    }
}