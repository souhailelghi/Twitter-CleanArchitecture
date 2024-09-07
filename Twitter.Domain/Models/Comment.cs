using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Domain.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        public string Text { get; set; }

        // Foreign key for Tweet
        [ForeignKey("Tweet")]
        public Guid TweetId { get; set; }

        // Foreign key for User
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        // Navigation properties
        public Tweet Tweet { get; set; }

        public User User { get; set; }

    }
}
