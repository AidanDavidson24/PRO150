using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Poke_Adventures.Models;

namespace Poke_Adventures.Data
{
		public class PokeAdventureDbContext : IdentityDbContext
		{
			public PokeAdventureDbContext(DbContextOptions<PokeAdventureDbContext> options)
				: base(options)
			{
			}

			public DbSet<UserName> UserNames { get; set; }
			public DbSet<Password> passwords { get; set; }
			public DbSet<Comment> Comments { get; set; }
		}
}
