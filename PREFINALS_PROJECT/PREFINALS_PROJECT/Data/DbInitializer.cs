using PREFINALS_PROJECT.Models;

namespace PREFINALS_PROJECT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tickets.Any()) return; // DB seeded

            var depts = new Department[]
            {
                new Department { Name = "IT Support", Description = "Handles software and network issues" },
                new Department { Name = "Hardware", Description = "Manages physical infrastructure" }
            };
            context.Departments.AddRange(depts);
            context.SaveChanges();

            var tickets = new Ticket[]
            {
                new Ticket { Title = "VPN Disconnects", Description = "Remote connection drops frequently", Priority = "High", Status = "Open" },
                new Ticket { Title = "Monitor Flicker", Description = "Secondary monitor flickers on startup", Priority = "Low", Status = "Open" }
            };
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
