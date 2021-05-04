using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public bool Perecivel { get; set; }
        public int CategoriaID { get; set; }

        public string CategoriaNome { get; set; }
    }
}