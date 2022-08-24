using MeetupAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Data
{
    public class MeetupDbContext : DbContext
    {
        public MeetupDbContext(DbContextOptions<MeetupDbContext> options) : base(options) { }

        public DbSet<Meetup> Meetups { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Organizer> Organizers { get; set; } = null!;
        public DbSet<Plan> Plans { get; set; } = null!;
        public DbSet<Speaker> Speakers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetup>().HasData(
                new Meetup() { Id = 1, Title = "Первое мероприятие", Topic = "Тема первого мероприятия", Description = "Описание первого мероприятия", DateTime = new DateTime(2031, 11, 11, 11, 11, 11) },
                new Meetup() { Id = 2, Title = "Второе мероприятие", Topic = "Тема второго мероприятия", Description = "Описание второго мероприятия", DateTime = new DateTime(2032, 12, 22, 22, 22, 22) });

            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = 1, City = "Первый", Street = "Первая", House = 11 },
                new Address() { Id = 2, City = "Второй", Street = "Вторая", House = 22 });

            modelBuilder.Entity<Organizer>().HasData(
                new Organizer() { Id = 1, FirstName = "Первый", LastName = "First", OrganizationOrTopic = "Первая организация", MeetupId = 1 },
                new Organizer() { Id = 2, FirstName = "Второй", LastName = "Second", OrganizationOrTopic = "Вторая организация", MeetupId = 1 },
                new Organizer() { Id = 3, FirstName = "Третий", LastName = "Third", OrganizationOrTopic = "Третья организация", MeetupId = 2 },
                new Organizer() { Id = 4, FirstName = "Четвёртый", LastName = "Fourth", OrganizationOrTopic = "Четвёртая организация", MeetupId = 2 });

            modelBuilder.Entity<Plan>().HasData(
                new Plan() { Id = 1, Item = "Первый", MeetupId = 1 },
                new Plan() { Id = 2, Item = "Второй", MeetupId = 1 },
                new Plan() { Id = 3, Item = "Первый", MeetupId = 2 },
                new Plan() { Id = 4, Item = "Второй", MeetupId = 2 });

            modelBuilder.Entity<Speaker>().HasData(
                new Speaker() { Id = 1, FirstName = "Первый", LastName = "First", OrganizationOrTopic = "Первая тема", MeetupId = 1 },
                new Speaker() { Id = 2, FirstName = "Второй", LastName = "Second", OrganizationOrTopic = "Вторая тема", MeetupId = 1 },
                new Speaker() { Id = 3, FirstName = "Третий", LastName = "Third", OrganizationOrTopic = "Третья тема", MeetupId = 2 },
                new Speaker() { Id = 4, FirstName = "Четвёртый", LastName = "Fourth", OrganizationOrTopic = "Четвёртая тема", MeetupId = 2 });
        }
    }
}
