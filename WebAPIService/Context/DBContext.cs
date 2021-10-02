using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIService.Models;

namespace WebAPIService.Context
{
    public class DBContext : DbContext 
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}