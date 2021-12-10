using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaAPIs.Models
{
    public class ToDoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option)
            : base(option)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Produto> todoProducts { get; set; }
    }
}
