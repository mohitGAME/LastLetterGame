using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcLastLetter.Entities
{
    public class Chat
    {
        // [ForeignKey("User")]
        // public long From { get; set; }

        // // [ForeignKey("User")]
        // public long To { get; set; }

        public long Message { get; set; }

        public long Id { get; set; }

        [Required]
        public GrpcLastLetter.Entities.User From { get; set; }

        [Required]
        public GrpcLastLetter.Entities.User To { get; set; }
        // [ForeignKey("FromId")]
        // public long UserId { get; set; }

    }
}