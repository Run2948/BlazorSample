using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Game.Entities.RequestFeatures
{
    public class PlayerParameter : QueryStringParameters
    {
        public DateTime MinDateCreated { get; set; }
        public DateTime MaxDateCreated { get; set; } = DateTime.Now;

        public bool ValidDateCreatedRange => MaxDateCreated > MinDateCreated;

        public string Account { get; set; }

        public PlayerParameter()
        {
            OrderBy = "account";
        }
    }
}
