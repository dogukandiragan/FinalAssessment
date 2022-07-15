using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalAssessment.Core.DTOs
{

    public class CustomerDto
    {

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Imagestring { get; set; }

        [JsonIgnore]
        public byte[] Image { get; set; }
        public string CallNumber { get; set; }
        public string City { get; set; }
    }
}