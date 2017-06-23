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
        object Consultar(object numeroTelefone, object cpf, object dataNascimeto);
        object Consultar(object numeroTelefone, string cpf, object dataNascimeto);
    }
}
