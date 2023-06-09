﻿using System.ComponentModel.DataAnnotations;

namespace Massarat_BackEnd.DTO
{
	public class RegisterDTO
	{
        [Required]
        [StringLength(50)]
        public string mobileNumber { get; set; }


        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; } = null!;
      
        public string? FirstName { get; set; }
		[Required]

		[StringLength(50, MinimumLength = 5)]
		public string ConfirmPassword { get; set; }
    }
}
