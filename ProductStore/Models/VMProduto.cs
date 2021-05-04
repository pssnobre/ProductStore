using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class VMProduto
    {
        public IEnumerable<Produto> Lista { get; set; }

        public IEnumerable<Categoria> ListaCategoria { get; set; }

        public Produto Produto { get; set; }

        public Categoria Categoria { get; set; }
    }
}