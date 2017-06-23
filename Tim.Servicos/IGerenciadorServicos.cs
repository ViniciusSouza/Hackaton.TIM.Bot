using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tim.Servicos
{
    public interface IGerenciadorServicos
    {
        Tuple<bool, string> Contratar(List<ServicoDTO> servicos, string numero);

        Tuple<bool, string> Cancelar(List<ServicoDTO> servicos, string numero);
    }
}
