﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mystro.Models
{
	public class Category
	{
		// Primary key
		[Key]
		public int Id { get; set; }
		[Required] // Not null
		[MaxLength(30)] // Length Validation
		[DisplayName("Category Name")] // for client side UI
		public string Name { get; set; }
		[DisplayName("Display Order")] // for client side UI
		[Range(1, 100)] // Range Validation
		public int DisplayOrder { get; set; }
	}
}