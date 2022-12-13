/*
 * Name: Shivam Janda
 * Date: December 12, 2022
 * Description: Workout class and its properties
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab5Workout.Models
{
    public class Workout
    {
        [Key] // primary key 
        [DisplayName("Workout Number")] // display name (table header on website) changed 
        public int workoutID { get; set; }

        [DisplayName("Workout Name")] // display name (table header on website) changed 
        public string workoutName { get; set; }

        [DisplayName("Sets")] // display name (table header on website) changed 
        public int sets { get; set; }

        [DisplayName("Reps")] // display name (table header on website) changed 
        public int reps { get; set; }

        [DisplayName("Date")] // display name (table header on website) changed 
        public string notes { get; set; }
    }
}
