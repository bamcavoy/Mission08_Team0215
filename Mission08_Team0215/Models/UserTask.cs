using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0215.Models
{
    public class UserTask
    {
        // required fields: task, quadrant
        [Key]
        [Required]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        //prevent due date from being before start date?
        public DateTime? DueDate { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "The value for quadrant must be between 1 and 4")]
        public int Quadrant { get; set; }

        //set foreign key relationship
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? Completed { get; set; }

    }
}