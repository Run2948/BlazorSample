using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sample.Game.Entities.Models
{
    public class Character
    {
        [Column("CharacterId")]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string Nickname { get; set; }

        [StringLength(20)]
        public string Classes { get; set; }

        public int Level { get; set; }
        public DateTime DateCreated { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
