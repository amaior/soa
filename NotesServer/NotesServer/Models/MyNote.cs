using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesServer.Models
{
    public class MyNote
    {
        public int MyNoteId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
