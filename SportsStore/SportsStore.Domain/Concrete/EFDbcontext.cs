﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SportsStore.Domain.Entities;
namespace SportsStore.Domain.Concrete
{
   public class EFDbcontext:DbContext
    {
        public DbSet<Product> product { get;set; }
        public DbSet<logDetail> logDetail { get; set; }
    }
}
