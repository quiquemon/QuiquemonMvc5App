namespace QuiquemonMvc5App.Migrations
{
    using System;
	using System.Collections.Generic;
    using System.Data.Entity.Migrations;
	using Models;
	using Models.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDbContext context)
        {
			context.Users.AddRange(new List<User> {
				new User {
					ID = 1,
					Name = "Enrique",
					Lastname = "Hernández",
					Birthday = new DateTime(1994, 1, 28),
					Email = "lenrique@numeri.mx",
					//Password = "$2a$14$aM3nSxxAvvxVxmL7orrbN.Qf0za3/eWMOq3ifjZEvT0wFLo344XXK",
					Password = "1234567890",
					Newsletter = false
				},
				new User {
					ID = 2,
					Name = "Marcianito",
					Lastname = "Fake",
					Birthday = new DateTime(1990, 12, 1),
					Email = "marcianito@numeri.mx",
					//Password = "$2a$14$aM3nSxxAvvxVxmL7orrbN.Qf0za3/eWMOq3ifjZEvT0wFLo344XXK",
					Password = "1234567890",
					Newsletter = true
				}
			});

			context.Logos.AddRange(new List<Logo> {
				new Logo {
					ID = 1,
					Name = "glyphicon glyphicon-user"
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
