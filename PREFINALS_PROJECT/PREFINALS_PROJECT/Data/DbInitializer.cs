using PREFINALS_PROJECT.Models;

namespace PREFINALS_PROJECT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Creates the database and all tables if they do not exist
            context.Database.EnsureCreated();

            // Seed Departments
            if (!context.Departments.Any())
            {
                var depts = new Department[]
                {
                    new Department { Name = "IT Support", Description = "Handles technical issues" },
                    new Department { Name = "Customer Success", Description = "Handles client onboarding" }
                };
                context.Departments.AddRange(depts);
                context.SaveChanges();
            }

            // Seed Tickets
            if (!context.Tickets.Any())
            {
                var tickets = new Ticket[]
                {
                    new Ticket { Title = "System Access Issue", Description = "User cannot log in", Priority = "High", Status = "Open" },
                    new Ticket { Title = "Printer Connectivity", Description = "Office printer offline", Priority = "Low", Status = "Open" }
                };
                context.Tickets.AddRange(tickets);
                context.SaveChanges();
            }
        }
    }
}