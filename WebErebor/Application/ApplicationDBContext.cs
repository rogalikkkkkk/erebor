﻿using BuisnessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace WebErebor.Application;

public class ApplicationDBContext : DbContext
{
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Lector> Lectors { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Cources { get; set; }

    public ApplicationDBContext()
    {
        Database.EnsureCreated();
        //TODO: Заполнить бд начальными данными
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=erebor_db;Username=soso;Password=soso");
    }
    
}