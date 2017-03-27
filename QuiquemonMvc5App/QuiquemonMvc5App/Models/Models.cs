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

		public string Name { get; set; }

		public virtual User User { get; set; }
	}

	public class User
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public string Lastname { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Birthday { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public bool Newsletter { get; set; }

		public virtual Logo Logo { get; set; }
		public virtual ICollection<UserTeam> UserTeams { get; set; }
		public virtual ICollection<Team> Teams { get; set; }
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

		public string Name { get; set; }

		public DateTime CreationDate { get; set; }

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

		public bool Status { get; set; }

		public string Transaction { get; set; }

		public decimal Amount { get; set; }

		public DateTime Completed { get; set; }

		public int TeamID { get; set; }

		public virtual Team Team { get; set; }
	}
}