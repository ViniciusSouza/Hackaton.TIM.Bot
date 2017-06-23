using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tim.Servicos
{
    public interface IConsultaServicos
    {
        List<ServicoDTO> ListarServicosDisponiveis(string numero);
        List<ServicoDTO> ListarServicosContratados(string numero);
    }
}
