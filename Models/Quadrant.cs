using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6GroupAssignment.Models
{
    public class Quadrant
    {
        [Key]
        [Required]
        public int EntryId { get; set; }

        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }

        [Required]
        public int QuadrantNumber { get; set; }

        public bool Completed { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
