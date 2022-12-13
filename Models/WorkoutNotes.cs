/*
 * Name: Shivam Janda
 * Date: December 12, 2022
 * Description: WorkoutNotes class and its properties
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Lab5Workout.Models
{
    public class WorkoutNotes
    {
        [Key]// primary key 
        public int wID { get; set; }

        [DisplayName("Workout Notes")] // display name (table header on website) changed 
        public string description { get; set; }
        
        public int? workoutID { get; set; }

        [ForeignKey("workoutID")]  // foreign key linked to workoutID from workout.cs
        [DisplayName("Related to what workout ID")] // display name (table header on website) changed 
        public virtual Workout exerciseID { get; set; }


      

    }
}
