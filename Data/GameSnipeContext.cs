using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameSnipe.Models;

namespace GameSnipe.Data
{
    public class GameSnipeContext : DbContext
    {
        public GameSnipeContext (DbContextOptions<GameSnipeContext> options)
            : base(options)
        {
        }

        public DbSet<GameSnipe.Models.CommentsEntry> CommentsEntry { get; set; } = default!;
    }
}
