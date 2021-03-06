﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly
{
    public class VidlyContext:DbContext
    {

        public VidlyContext() : base("VidlyDB") { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
    }
}