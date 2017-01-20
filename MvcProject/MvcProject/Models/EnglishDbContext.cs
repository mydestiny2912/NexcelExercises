﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class EnglishDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Pharse> Pharses { get; set; }
        public DbSet<Example> Examples { get; set; }
    }
}