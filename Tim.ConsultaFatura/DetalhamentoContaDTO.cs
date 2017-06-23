using System;
using System.Collections.Generic;

namespace Tim.ConsultaFatura
{
    public class DetalhamentoContaDTO
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public List<LinhaDetalhe> Detalhes { get; set; }

      }
}