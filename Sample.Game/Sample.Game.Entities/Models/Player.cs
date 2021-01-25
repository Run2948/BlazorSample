using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Game.Entities.Models
{
    public class Player
    {
        [Column("PlayerId")]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(10)]
        public string AccountType { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Character> Characters { get; set; }

        public Player()
        {
            DateCreated = DateTime.Now;
        }
    }
}
