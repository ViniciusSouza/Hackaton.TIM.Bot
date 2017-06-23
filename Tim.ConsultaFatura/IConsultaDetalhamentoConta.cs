using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tim.ConsultaFatura
{
    public interface IConsultaDetalhamentoConta
    {
        DetalhamentoContaDTO Consultar(string numeroTelefone, string cpf, DateTime dataNascimento);
    }
}
