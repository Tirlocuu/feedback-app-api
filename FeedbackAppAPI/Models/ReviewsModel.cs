using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppAPI.Models
{
    public class ReviewsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public short Rate { get; set; }

        override
        public string ToString()
        {
            return Id + ";" + Name + ";" + Email + ";" + Comment + ";" + Rate;
        }
    }
}
