using System.ComponentModel.DataAnnotations;

namespace FinalAssessment.Core.Models
{
    public class UserRefreshToken
    {
        [Key]
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
