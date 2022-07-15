using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
 
namespace FinalAssessment.Core.Models
{
    public class CustomerApp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

      
        public byte[] Image { get; set; }
        public string CallNumber { get; set; }  
        public string City { get; set; }

    }
}
