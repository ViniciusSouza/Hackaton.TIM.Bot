using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Tim.ConsultaFatura;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    public class DetalhamentoDeUsoDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            // TODO: FormFlow para recuperar as informacoes - callback
            return Task.CompletedTask;
        }


        private void CallBackFormFlow(IDialogContext context, InputConsulta inputConsulta)
        {
            var consulta = Carubbi.Utils.IoC.ImplementationResolver.Resolve<IConsultaDetalhamentoConta>();
            var fatura = consulta.Consultar(inputConsulta.NumeroTelefone, inputConsulta.Cpf, inputConsulta.DataNascimeto);
            var message = context.MakeMessage();
            message.AsMessageActivity().Attachments.Add(new Attachment(contentType: "fatura", content: fatura));
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;

            // TODO: Put logic for handling user message here

            context.Wait(MessageReceivedAsync);
        }
    }
}