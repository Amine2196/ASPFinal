﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPFinal.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HenryBookstoreASPDatabase : DbContext
    {
        public HenryBookstoreASPDatabase()
            : base("name=HenryBookstoreASPDatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTHOR> AUTHORs { get; set; }
        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<BRANCH> BRANCHes { get; set; }
        public virtual DbSet<INVENTORY> INVENTORies { get; set; }
        public virtual DbSet<PUBLISHER> PUBLISHERs { get; set; }
        public virtual DbSet<WROTE> WROTEs { get; set; }
    }
}
