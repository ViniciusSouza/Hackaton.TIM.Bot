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

        InputConsulta _inputConsulta = new InputConsulta();

        public Task StartAsync(IDialogContext context)
        {
            // TODO: FormFlow para recuperar as informacoes - callback
            PromptDialog.Text(context, ResumeAfterCPF, "Informe o seu CPF: ");

            return Task.CompletedTask;
        }


        private async Task CallBackFormFlow(IDialogContext context, InputConsulta inputConsulta)
        {
            var consulta = Carubbi.Utils.IoC.ImplementationResolver.Resolve<IConsultaDetalhamentoConta>();
            var fatura = consulta.Consultar(inputConsulta.NumeroTelefone, inputConsulta.Cpf, inputConsulta.DataNascimeto);
            var message = context.MakeMessage();
            message.AsMessageActivity().Attachments.Add(new Attachment(contentType: "fatura", content: fatura));
            await context.PostAsync(message);

            context.Done("");
        }

        

        private async Task ResumeAfteDataNascimento(IDialogContext context, IAwaitable<string> result)
        {
            var strdata = await result;
            DateTime dataNascimento;
            //TODO: Validade  Data de Nascimento
            if (!string.IsNullOrEmpty(strdata) && DateTime.TryParse(strdata, out dataNascimento))
            {
                _inputConsulta.DataNascimeto = dataNascimento;
                
                PromptDialog.Text(context, ResumeAfteNumeroTelefone, "Informe  o número de telefone: ");

            }
            else
            {
                var msg = context.MakeMessage();
                msg.Text = "A data de Nascimento não é uma data válida! Tente novamente";
                await context.PostAsync(msg);

                PromptDialog.Text(context, ResumeAfteDataNascimento, "Informe sua Data de Nascimento: ");
            }
        }

        private async Task ResumeAfteNumeroTelefone(IDialogContext context, IAwaitable<string> result)
        {
            var telefone = await result;
            //TODO: Validade  CPF
            if (!string.IsNullOrEmpty(telefone))
            {
                _inputConsulta.NumeroTelefone = telefone;

                await CallBackFormFlow(context, _inputConsulta);
            }
            else
                PromptDialog.Text(context, ResumeAfteNumeroTelefone, "Informe  o número de telefone: ");
        }

        private async Task ResumeAfterCPF(IDialogContext context, IAwaitable<string> result)
        {
            var cpf = await result;
            //TODO: Validade  CPF
            if (!string.IsNullOrEmpty(cpf))
            {
                _inputConsulta.Cpf = await result;
                PromptDialog.Text(context, ResumeAfteDataNascimento, "Informe sua Data de Nascimento: ");
            }
            else
                PromptDialog.Text(context, ResumeAfterCPF, "Informe o seu CPF: ");

            
        }
    }
}