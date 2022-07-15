using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalAssessment.Core.DTOs
{

    public class TransactionDto
    {
 
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string UserId { get; set; }
 
        public string Service { get; set; }
        public double Price { get; set; }
    }
}
