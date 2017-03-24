using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuiquemonMvc5App.Models
{
	public class Logo
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int UserID { get; set; }

		public virtual User User { get; set; }
	}

	public class User
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Lastname { get; set; }
		public DateTime Birthday { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool Newsletter { get; set; }

		public virtual Logo Logo { get; set; }
		public virtual ICollection<UserTeam> UserTeams { get; set; }
	}

	public class UserTeam
	{
		public int UserID { get; set; }
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
		public int UserID { get; set; }

		public virtual ICollection<UserTeam> UserTeams { get; set; }
		public virtual ICollection<Payment> Payments { get; set; }
	}

	public class Payment
	{
		public int ID { get; set; }
		public bool Status { get; set; }
		public string TransactionID { get; set; }
		public decimal Amount { get; set; }
		public DateTime Completed { get; set; }
		public int TeamID { get; set; }

		public virtual Team Team { get; set; }
	}
}