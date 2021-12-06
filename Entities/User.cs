using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcLastLetter.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [ForeignKey("FromId")]
        [InverseProperty("From")]
        public List<GrpcLastLetter.Entities.Chat> ChatsFrom { get; set; }

        [ForeignKey("ToId")]
        [InverseProperty("To")]
        public List<GrpcLastLetter.Entities.Chat> ChatsTo { get; set; }


    }
}