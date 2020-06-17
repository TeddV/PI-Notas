using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniNotasApi.Models
{
    public class Note
    {
        [Key]
        public long Id { get; set; }

        public string Image { get; set; }

        [Column(TypeName = "varchar(1024)")]
        [MaxLength(1024, ErrorMessage = "Este campo deve conter entre 3 e 1024 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 1024 caracteres")]
        public string Text { get; set; }
        public string Video { get; set; }
        public DateTime CreateDate { get; set; }
        public long BookId { get; set; }
        public Book Book { get; set; }

    }
}
