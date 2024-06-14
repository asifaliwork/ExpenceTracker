using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenceTracker.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expence")]
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        [Range (0, int.MaxValue, ErrorMessage ="Amount Must be greater then 0! ")]
        public int Amount { get; set; }

        [DisplayName ("Expense Type")]
        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType? ExpenseType { get; set; }
    } 
}
