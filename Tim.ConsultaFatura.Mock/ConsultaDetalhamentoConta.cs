using Carubbi.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tim.ConsultaFatura.Mock;

namespace Tim.ConsultaFatura.Mock
{
    public class ConsultaDetalhamentoConta : IConsultaDetalhamentoConta
    {
        public DetalhamentoContaDTO Consultar(string numeroTelefone, string cpf, DateTime dataNascimento)
        {
            
            
            return new DetalhamentoContaDTO
            {
                CPF = cpf,
                DataNascimento = dataNascimento,
                Detalhes = new List<LinhaDetalhe>
                {
                    new LinhaDetalhe
                    {
            
                        DataHora = "17/06/2017 16:00".To<DateTime>().Value,
                        Descricao = "Chamada recebida",
                        Duracao = new TimeSpan(0,0,0,234),
                        Saldo = 20,
                        Tipo = TipoDetalhe.Ligacao,
                        Valor = 0.14M
                    },
                    new LinhaDetalhe
                    {
                        DataHora = "22/06/2017 21:00".To<DateTime>().Value,
                        Descricao = "Chamada efetuada",
                        NumeroDestino = "11986556339",
                        Duracao = new TimeSpan(0,0,0,563),
                        Saldo = 19.81M,
                        Tipo = TipoDetalhe.Ligacao,
                        Valor = 0.19M
                    },
                     new LinhaDetalhe
                    {
                        DataHora = "21/06/2017 20:00".To<DateTime>().Value,
                        Descricao = "Dados",
                        Saldo = 19.63M,
                        Tipo = TipoDetalhe.Internet,
                        Valor = 0.18M,
                        MbytesEnviados = 5,
                        MBytesRecebidos = 7.4M
                    },
                    new LinhaDetalhe
                    {
                        DataHora = "22/06/2017 14:00".To<DateTime>().Value,
                        Descricao = "Chamada efetuada",
                        NumeroDestino = "31993663763",
                        Duracao = new TimeSpan(0,0,0,343),
                        Saldo = 19.51M,
                        Tipo = TipoDetalhe.Ligacao,
                        Valor = 0.12M
                    },
                    new LinhaDetalhe
                    {
                        DataHora = "24/06/2017 19:00".To<DateTime>().Value,
                        Descricao = "Chamada recebida",
                        NumeroDestino = "31993663763",
                        Duracao = new TimeSpan(0,0,0,543),
                        Saldo = 19.34M,
                        Tipo = TipoDetalhe.Ligacao,
                        Valor = 0.17M
                    },
                        new LinhaDetalhe
                    {
                        DataHora = "25/06/2017 15:00".To<DateTime>().Value,
                        Descricao = "Chamada recebida",
                        Duracao = new TimeSpan(0,0,0,321),
                        Saldo = 19.21M,
                        Tipo = TipoDetalhe.Ligacao,
                        Valor = 0.13M
                    },
                         new LinhaDetalhe
                    {
                        DataHora = "25/06/2017".To<DateTime>().Value,
                        Descricao = "Dados",
                        Saldo = 19,
                        Tipo = TipoDetalhe.Internet,
                        Valor = 0.21M,
                        MBytesRecebidos = 6,
                        MbytesEnviados = 7
                    },
                          new LinhaDetalhe
                    {
                        DataHora = "26/06/2017".To<DateTime>().Value,
                        Descricao = "Chamada recebida",
                        Duracao = new TimeSpan(0,0,0,234),
                        Saldo = 18.85M,
                        Tipo = TipoDetalhe.Ligacao,
                        Valor = 0.15M
                    },
                },
                Nome = "Ulisses Santos"
            };
        }
    }
}
