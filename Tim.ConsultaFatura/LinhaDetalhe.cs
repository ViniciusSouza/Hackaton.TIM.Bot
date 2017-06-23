using System;

namespace Tim.ConsultaFatura
{
    public class LinhaDetalhe
    {
        public TipoDetalhe Tipo { get; set; }
        public DateTime DataHora { get; set; }
        public string NumeroDestino { get; set; }

        public string Descricao { get; set; }

        public TimeSpan Duracao { get; set; }

        public decimal Valor { get; set; }

        public decimal Saldo { get; set; }

        public decimal MbytesEnviados { get; set; }

        public decimal MBytesRecebidos { get; set; }
    }
}