using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAssessment.Core.Models
{
    public class TransactionApp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Datetime { get; set; } = DateTime.Now;

        public string Service { get; set; }
        public double Price { get; set; }


    }
}
