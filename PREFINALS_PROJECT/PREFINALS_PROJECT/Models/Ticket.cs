using System.ComponentModel.DataAnnotations;

namespace PREFINALS_PROJECT.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Priority { get; set; } = "Low"; // Low, Medium, High, Critical

        [Required]
        public string Status { get; set; } = "Open"; // Open, In Progress, Resolved, Closed

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
