using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Domain.Models
{
    public class Tweet
    {
        [Key]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        // Navigation property for User
        public User User { get; set; }

        // Navigation property for Comments
        public ICollection<Comment> Comments { get; set; }

    }
}
