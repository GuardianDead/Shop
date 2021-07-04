using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class AppDBIdentity : IdentityDbContext
    {
        public AppDBIdentity(DbContextOptions<AppDBIdentity> options) : base(options)
        {
        }
    }
}
