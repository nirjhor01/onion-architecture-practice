using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainlayerClassLibrary1.Model
{
    public class User
    {
        [Key]
        public long UserId { get; set; }


        public string? UserName { get; set; }
        public string? UserPhone { get; set; }
        public string? UserEmailId { get; set; }
        public string? UserAddress { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set;}
    }
}
