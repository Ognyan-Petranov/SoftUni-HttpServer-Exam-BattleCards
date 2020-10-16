using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class Card
    {
        public Card()
        {
            this.Users = new HashSet<UserCard>();
        }

        [Key]
        public int CardId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Keyword { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        public string Description { get; set; }

        public ICollection<UserCard> Users { get; set; }
    }
}
