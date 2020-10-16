using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class User
    {
        public User()
        {
            this.UserId = Guid.NewGuid().ToString();
            this.Cards = new HashSet<UserCard>();
        }

        [Key]
        public string UserId { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserCard> Cards { get; set; }
    }
}
