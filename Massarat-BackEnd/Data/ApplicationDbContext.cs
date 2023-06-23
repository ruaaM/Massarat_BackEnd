using System.Collections.Generic;
using Massarat.Models;
using Massarat_BackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Massarat.Data
{
	public class ApplicationDbContext: IdentityDbContext<User>
	{
		public ApplicationDbContext()
		{
		}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}
		public DbSet<Mentor> Mentor { get; set; }
		public DbSet<Project> Project { get; set; }
		public DbSet<Student> Student { get; set; }
		public DbSet<University> University { get; set; }
		public DbSet<UserImage> UserImage { get; set; }

	}
}
