using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackaton.TIM.Bot.Models
{
    [Serializable]
    public class DetalhamentoContaRequest
    {
        private static FormBuilder<T> CreateFormBuilderPTBR<T>(string message) where T : class
        {
            var builder = new FormBuilder<T>();
            builder.Message(message);
            builder.Configuration.Yes = new string[] { "Sim", "Está", "Estão", "Correto", "Certo", "OK", "1" };
            builder.Configuration.No = new string[] { "Não", "Não está", "Não estão", "Errado", "Incorreto", "2", "nao", "nenhum" };
            builder.Configuration.NoPreference = new string[] { "nenhum", "Nenhum", "Não", "-", "nada" };



            builder.Configuration.DefaultPrompt.ChoiceLastSeparator = ", ou ";
            builder.Configuration.DefaultPrompt.LastSeparator = ", e ";

            builder.Configuration.Navigation = "Nome do campo";
            builder.Configuration.Template(TemplateUsage.BoolHelp).Patterns = new string[] { "Por favor responda 'sim' ou 'não'{?, {0}}." };
            builder.Configuration.Template(TemplateUsage.Bool).Patterns = new string[] { "Você gostaria de um(a) {&}? {||}" };
            builder.Configuration.Template(TemplateUsage.Clarify).Patterns = new string[] { "Por \"{0}\" {&} você quis dizer {||}" };
            builder.Configuration.Template(TemplateUsage.Confirmation).Patterns = new string[] { "Confira se as informações estão corretas.\r\n{*}" };
            builder.Configuration.Template(TemplateUsage.CurrentChoice).Patterns = new string[] { "(Escolha atual: {})" };
            builder.Configuration.Template(TemplateUsage.DateTime).Patterns = new string[] { "Por favor, digite uma data e hora para {&} {||}" };
            builder.Configuration.Template(TemplateUsage.DateTimeHelp).Patterns = new string[] { "Por favor digite uma expressão de data e hora {?, {0}}{?, {1}}." };
            builder.Configuration.Template(TemplateUsage.Double).Patterns = new string[] { "Por favor informe um número {?entre {0:F1} e {1:F1}} para {&} {||}" };
            builder.Configuration.Template(TemplateUsage.DoubleHelp).Patterns = new string[] { "Por favor informe um número{? entre {2:F1} e {3:F1}}{?, {0}}{?, {1}}." };
            builder.Configuration.Template(TemplateUsage.EnumManyNumberHelp).Patterns = new string[] { "Você pode informar um ou mais números {0}-{1} ou palavras a partir das descrições. ({2})" };
            builder.Configuration.Template(TemplateUsage.EnumManyWordHelp).Patterns = new string[] { "Você pode informar uma ou mais seleções a partir das descrições. ({2})" };
            builder.Configuration.Template(TemplateUsage.EnumOneNumberHelp).Patterns = new string[] { "Você pode informar um número {0}-{1} ou palavras a partir das descrições. ({2})" };
            builder.Configuration.Template(TemplateUsage.EnumOneWordHelp).Patterns = new string[] { "Você pode informar qualquer palavra a partir das descrições. ({2})" };
            builder.Configuration.Template(TemplateUsage.EnumSelectMany).Patterns = new string[] { "Por favor, informe um(a) ou mais {&} {||}" };
            builder.Configuration.Template(TemplateUsage.EnumSelectOne).Patterns = new string[] { "Por favor selecione um(a) {&} {||}" };
            builder.Configuration.Template(TemplateUsage.Feedback).Patterns = new string[] { "Para '{&}' eu entendi {}." }; // {?\"{0}\" não é uma opção válida.}
            builder.Configuration.Template(TemplateUsage.Help).Patterns = new string[] { "Você está preenchendo o campo {&}.  Resposta possível:\r\n{0}\r\n{1}" };
            builder.Configuration.Template(TemplateUsage.HelpClarify).Patterns = new string[] { "Você está confirmando o valor de {&}.  Resposta possível:\r\n{0}\r\n{1}" };
            builder.Configuration.Template(TemplateUsage.HelpConfirm).Patterns = new string[] { "Por favor responda a pergunta.  Resposta possível:\r\n{0}\r\n{1}" };
            builder.Configuration.Template(TemplateUsage.HelpNavigation).Patterns = new string[] { "Escolha qual campo deseja modificar.  Resposta possível:\r\n{0}\r\n{1}" };
            builder.Configuration.Template(TemplateUsage.Integer).Patterns = new string[] { "Por favor informe um número{? entre {0} e {1}} para {&} {||}" };
            builder.Configuration.Template(TemplateUsage.IntegerHelp).Patterns = new string[] { "Você pode informar um número{? entre {2} e {3}}{?, {0}}{?, {1}}." };
            builder.Configuration.Template(TemplateUsage.Navigation).Patterns = new string[] { "O que você dejeja alterar? {||}" };
            builder.Configuration.Template(TemplateUsage.NavigationCommandHelp).Patterns = new string[] { "Você pode alternar entre os campos informando seu nome. ({0})." };
            builder.Configuration.Template(TemplateUsage.NavigationFormat).Patterns = new string[] { "{&}({})" };
            builder.Configuration.Template(TemplateUsage.NavigationHelp).Patterns = new string[] { "Escolha {?um número de {0}-{1}, ou} o nome de um campo." };
            builder.Configuration.Template(TemplateUsage.NoPreference).Patterns = new string[] { "Sem preferência" };
            builder.Configuration.Template(TemplateUsage.NotUnderstood).Patterns = new string[] { "\"{0}\" não é uma opção para { &}." };
            builder.Configuration.Template(TemplateUsage.StatusFormat).Patterns = new string[] { "{&}: {}" };
            builder.Configuration.Template(TemplateUsage.String).Patterns = new string[] { "Por favor, informe {&} {||}" };
            builder.Configuration.Template(TemplateUsage.StringHelp).Patterns = new string[] { "Você pode digitar o que quiser (use \"'s para forçar texto){?, {0}}{?, {1}}." };
            builder.Configuration.Template(TemplateUsage.Unspecified).Patterns = new string[] { "Não especificado" };
            builder.Configuration.CurrentChoice = new string[] { "atual", "corrente" };
            builder.Configuration.Commands.Clear();
            builder.Configuration.Commands.Add(FormCommand.Help, new CommandDescription("Ajuda", new string[] { "/ajuda" }, "voce pode digitar /ajuda para saber quais comandos estão disponíveis"));
            builder.Configuration.Commands.Add(FormCommand.Backup, new CommandDescription("Voltar", new string[] { "/voltar" }, "voce pode digitar /voltar para responder novamente a questão anterior"));
            builder.Configuration.Commands.Add(FormCommand.Reset, new CommandDescription("Reiniciar", new string[] { "/reiniciar" }, "voce pode digitar /reiniciar para recomeçar este diálogo"));
            builder.Configuration.Commands.Add(FormCommand.Quit, new CommandDescription("Sair", new string[] { "/sair", "/start" }, "voce pode digitar /sair para desistir deste diálogo"));
            builder.Configuration.Commands.Add(FormCommand.Status, new CommandDescription("Status", new string[] { "/status" }, "voce pode digitar /status para visualizar suas respostas informadas até o momento"));
            return builder;
        }




        public static IForm<DetalhamentoContaRequest> BuildForm()
        {
            FormBuilder<DetalhamentoContaRequest> builder = CreateFormBuilderPTBR<DetalhamentoContaRequest>("Ok, então vou te pedir para confirmar alguns dados... (a qualquer momento digite /ajuda para mais opções)");
            return builder.Build();
        }

        [Describe("Telefone")]
        [Prompt("Qual o seu {&}?")]
        public string NumeroTelefone { get; set; }

        [Describe("CPF")]
        [Prompt("Qual o seu {&}?")]
        public string CPF { get; set; }

        [Describe("Data de nascimento")]
        [Prompt("Agora, me informe a sua {&}")]
        [Template(TemplateUsage.NotUnderstood, "Não entendi a {&}, pode preencher no padrão dd/MM/aaaa por favor?")]
        public DateTime DataNascimento { get; set; }
    }
}