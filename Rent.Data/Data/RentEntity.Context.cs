﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rent.Data.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class rentautomationdatabaseEntities : DbContext
    {
        public rentautomationdatabaseEntities()
            : base("name=rentautomationdatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<addresstable> addresstable { get; set; }
        public virtual DbSet<companytable> companytable { get; set; }
        public virtual DbSet<membertable> membertable { get; set; }
        public virtual DbSet<renttable> renttable { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<vehicletable> vehicletable { get; set; }
    }
}
