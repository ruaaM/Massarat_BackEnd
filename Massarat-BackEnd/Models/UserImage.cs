using Massarat.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Massarat_BackEnd.Models
{
    public class UserImage:General
    {
        [Key]
        public int UserImageID { get; set; }
        public String? FilePath { get; set; }
        public String? Title { get; set; }
        [StringLength(450)]
        public String? UserId { get; set; }
        public User? User { get; set; }
    }
}
