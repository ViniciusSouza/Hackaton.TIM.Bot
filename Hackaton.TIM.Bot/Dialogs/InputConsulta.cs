using System;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    internal class InputConsulta
    {
        public string Cpf { get;  set; }
        public DateTime? DataNascimeto { get;  set; }
        public string NumeroTelefone { get;  set; }
    }
}