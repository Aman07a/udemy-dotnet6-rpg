﻿using Microsoft.EntityFrameworkCore;

namespace udemy_dotnet6_rpg.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Character> Characters { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Weapon> Weapons { get; set; }
		public DbSet<Skill> Skills => Set<Skill>();
	}
}
