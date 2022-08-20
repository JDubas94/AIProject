using DataFile.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using System;

namespace MyProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        public DbSet<NeuralNetworkModel> NeuralNetworkModels { get; set; }
        public DbSet<NeuralNetworkType> NeuralNetworkTypes { get; set; }
    }
}
