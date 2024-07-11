using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Entities
{
    public partial class UserAccount
    {
        [Key]
        [Required]
        public int UserAccountId { get; set; }
        public string UserPassword { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public int? Role { get; set; }
    }
}
