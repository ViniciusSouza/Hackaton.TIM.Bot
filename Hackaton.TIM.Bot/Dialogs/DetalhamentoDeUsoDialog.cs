using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Tim.ConsultaFatura;
using Hackaton.TIM.Bot.Models;
using Microsoft.Bot.Builder.FormFlow;

namespace Hackaton.TIM.Bot.Dialogs
{
    [Serializable]
    public class DetalhamentoDeUsoDialog : IDialog<object>
    {

        private BuildFormDelegate<DetalhamentoContaRequest> _formFlow;

        public DetalhamentoDeUsoDialog(BuildFormDelegate<DetalhamentoContaRequest> formFlow)
        {
            _formFlow = formFlow;
        }
    

        public Task StartAsync(IDialogContext context)
        {
            var model = new DetalhamentoContaRequest();

            var detalhamentoContaForm = new FormDialog<DetalhamentoContaRequest>(model, this._formFlow, FormOptions.PromptInStart);
            context.Call(detalhamentoContaForm, CallBackFormFlow);
            return Task.CompletedTask;
        }


        private async Task CallBackFormFlow(IDialogContext context, IAwaitable<DetalhamentoContaRequest> input)
        {
            var inputConsulta = await input;
            var consulta = Carubbi.Utils.IoC.ImplementationResolver.Resolve<IConsultaDetalhamentoConta>();
            var fatura = consulta.Consultar(inputConsulta.NumeroTelefone, inputConsulta.CPF, inputConsulta.DataNascimento);
            var message = context.MakeMessage();
            message.AsMessageActivity().Attachments.Add(new Attachment(contentType: "fatura", content: fatura));
            await context.PostAsync(message);

            context.Done("");
        }

        

        

   
    }
}