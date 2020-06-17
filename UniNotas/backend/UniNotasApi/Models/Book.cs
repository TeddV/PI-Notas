using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniNotasApi.Models
{
    public class Book
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }
        public IEnumerable<Note> Notes { get; set; }

    }
}