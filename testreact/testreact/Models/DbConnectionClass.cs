using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testreact.Models
{
    public class DbConnectionClass : DbContext
    {
        public DbConnectionClass(DbContextOptions<DbConnectionClass> options) : base(options)
        {

        }

        public DbSet<WeatherModel> weatherdata { get; set; }


    }
}
