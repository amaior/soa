using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesServer.Models;

namespace NotesServer.Data
{
    public class NotesServerContext : DbContext
    {
        public NotesServerContext (DbContextOptions<NotesServerContext> options)
            : base(options)
        {
        }

        public DbSet<NotesServer.Models.Note> Note { get; set; }

        public DbSet<NotesServer.Models.MyNote> MyNote { get; set; }
    }
}
