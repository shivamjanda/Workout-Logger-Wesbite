/*
 * Name: Shivam Janda
 * Date: December 12, 2022
 * Description: Application db context class and its properties to set up database for workouts and workout notes
 */
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Lab5Workout.Models;

namespace Lab5Workout.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutNotes> WorkoutNotes { get; set; }

    }
}
