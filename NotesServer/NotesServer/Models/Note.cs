using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesServer.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
