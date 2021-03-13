using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Curso
    {
        [Column("IdCurso")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdCurso { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataTermino { get; set; }

        public int? NumeroAlunos { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        public Categoria Categoria { get; set; }

    }
}
