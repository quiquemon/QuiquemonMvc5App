using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuiquemonMvc5App.Models
{
	public class Logo
	{
		[ForeignKey("User")]
		public int ID { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		public virtual User User { get; set; }
	}

	public class User
	{
		public int ID { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(100)]
		public string Lastname { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }

		[Required]
		[MaxLength(70)]
		[Index(IsUnique = true)]
		public string Email { get; set; }

		[Required]
		[MaxLength(255)]
		public string Password { get; set; }

		[Required]
		public bool Newsletter { get; set; }

		public virtual Logo Logo { get; set; }
		public virtual ICollection<UserTeam> UserTeams { get; set; }
		public virtual ICollection<Team> Teams { get; set; }

		// Utility methods
		public string GetFullName() { return Name + " " + Lastname; }
	}

	public class UserTeam
	{
		[Key, Column(Order = 0)]
		public int UserID { get; set; }
		[Key, Column(Order = 1)]
		public int TeamID { get; set; }

		public virtual User User { get; set; }
		public virtual Team Team { get; set; }
	}

	public class Team
	{
		public int ID { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(200)]
		public string Description { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime CreationDate { get; set; }

		[Required]
		[MaxLength(80)]
		public string Code { get; set; }

		public int? OwnerID { get; set; }

		public virtual ICollection<UserTeam> UserTeams { get; set; }
		public virtual ICollection<Payment> Payments { get; set; }
		[ForeignKey("OwnerID")]
		public virtual User Owner { get; set; }
	}

	public class Payment
	{
		public int ID { get; set; }

		[Required]
		public bool Status { get; set; }

		[Required]
		[MaxLength(45)]
		public string Transaction { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Amount { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Completed { get; set; }

		public int TeamID { get; set; }

		public virtual Team Team { get; set; }
	}
}