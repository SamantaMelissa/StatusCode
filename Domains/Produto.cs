using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }

        //  [NotMapped]
        // [JsonIgnore]
        // public IFormFile Imagem { get; set; }

        //url da imagem
        //public string UrlImagem { get; set; }

        // 1 : N
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
