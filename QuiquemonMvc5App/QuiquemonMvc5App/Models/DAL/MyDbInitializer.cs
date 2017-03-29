using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace QuiquemonMvc5App.Models.DAL
{
	public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
	{
		protected override void Seed(MyDbContext context)
		{
			// Password = 1111111111
			context.Users.AddRange(new List<User> {
				new User {
					ID = 1,
					Name = "Enrique",
					Lastname = "Hernández",
					Birthday = new DateTime(1994, 1, 28),
					Email = "lenrique@numeri.mx",
					Password = "$2a$14$o1wV2nPLQA/vj559gtf3dO1IXksTxuze7gDH8DKuDxgckm2CMRE3e",
					Newsletter = false
				},
				new User {
					ID = 2,
					Name = "Marcianito",
					Lastname = "Fake",
					Birthday = new DateTime(1990, 12, 1),
					Email = "marcianito@numeri.mx",
					Password = "$2a$14$o1wV2nPLQA/vj559gtf3dO1IXksTxuze7gDH8DKuDxgckm2CMRE3e",
					Newsletter = true
				}
			});

			context.Logos.AddRange(new List<Logo> {
				new Logo {
					ID = 1,
					Name = "glyphicon glyphicon-cloud"
				},
				new Logo {
					ID = 2,
					Name = "glyphicon glyphicon-picture"
				}
			});

			context.Teams.AddRange(new List<Team> {
				new Team {
					ID = 1,
					Name = "Mi Primer Equipo",
					Description = "El primer equipo creado de esta aplicación.",
					Code = "abcdef",
					CreationDate = DateTime.Now,
					OwnerID = 1
				},
				new Team {
					ID = 2,
					Name = "AEIOUÑ",
					Description = "",
					Code = "012345",
					CreationDate = DateTime.Now,
					OwnerID = 1
				},
				new Team {
					ID = 3,
					Name = "áêìöýñ",
					Description = "Caracteres de Unicode.",
					Code = "6789ab",
					CreationDate = DateTime.Now,
					OwnerID = 1
				},
				new Team {
					ID = 4,
					Name = "Equipo Foráneo",
					Description = "Equipo foráneo :p",
					Code = "01cdef",
					CreationDate = DateTime.Now,
					OwnerID = 2
				}
			});

			context.UserTeams.AddRange(new List<UserTeam> {
				new UserTeam { UserID = 1, TeamID = 1 },
				new UserTeam { UserID = 1, TeamID = 2 },
				new UserTeam { UserID = 1, TeamID = 3 },
				new UserTeam { UserID = 1, TeamID = 4 },
				new UserTeam { UserID = 2, TeamID = 4 }
			});

			context.Payments.AddRange(new List<Payment> {
				new Payment {
					ID = 1,
					Status = true,
					Amount = 33.34M,
					Completed = DateTime.Now,
					Transaction = "01",
					TeamID = 1
				},
				new Payment {
					ID = 2,
					Status = true,
					Amount = 50M,
					Completed = DateTime.Now,
					Transaction = "02",
					TeamID = 2
				},
				new Payment {
					ID = 3,
					Status = true,
					Amount = 18.91M,
					Completed = DateTime.Now,
					Transaction = "03",
					TeamID = 3
				},
				new Payment {
					ID = 4,
					Status = true,
					Amount = 98.73M,
					Completed = DateTime.Now,
					Transaction = "04",
					TeamID = 4
				}
			});

			context.SaveChanges();
		}
	}
}