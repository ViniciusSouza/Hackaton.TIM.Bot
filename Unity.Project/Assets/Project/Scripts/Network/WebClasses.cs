using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Talent.Network
{
    //Contem classes helper para fazer as comunicacoes JSON com o servidor Parse
    /// <summary>
    /// Dados de um retorno que deu erro
    /// </summary>
    public class Error
    {
        public int code = -1;
        public string erro = "";
        public string mensagem = "";
    }
    /// <summary>
    /// Dados base que qualquer objeto tera
    /// </summary>
    public class BasicObjectData
    {
        /// <summary>
        /// COdigo do callback de web
        /// </summary>
        public int code = 200;
        public string id = "";
        public string createdAt = "";

        public void Copy(BasicObjectData _other)
        {
            code = _other.code;
            id = _other.id;
            createdAt = _other.createdAt;
        }
    }
    /// <summary>
    /// Dados de um retorno de login ou signup
    /// </summary>
    public class LoginSignData : BasicObjectData
    {
        public string nome = "";
        public string email = "";
        public string genero = "";
        public string dataNascimento = "";
        public string token = "";
        public string dataHora = "";
        public int intervalo = 0;
        public bool reseta = false;
        public string tipoTempo = "";
        public int quantidadeTempo = 5;
        public bool pulso = false;

        public void Copy(LoginSignData _other)
        {
            id = _other.id;
            nome = _other.nome;
            email = _other.email;
            genero = _other.genero;
            dataNascimento = _other.dataNascimento;
            token = _other.token;
            dataHora = _other.dataHora;
            intervalo = _other.intervalo;
            reseta = _other.reseta;
            tipoTempo = _other.tipoTempo;
            quantidadeTempo = _other.quantidadeTempo;
            pulso = _other.pulso;
        }
    }
    /// <summary>
    /// Dados de saved data de um usuario (para reconstruir o game state)
    /// </summary>
    public class SavedData : BasicObjectData
    {
        public string userId = "";
        public string savedData = "";

        public void Copy(SavedData _other)
        {
            id = _other.id;
            userId = _other.userId;
            savedData = _other.savedData;
        }
    }
    /// <summary>
    /// Dados recuperados de um pacote de conteudo de um modulo
    /// </summary>
    [System.Serializable]
    public class ModulePackData
    {
        public string id = "";
        public string cliente = "";
        public string modulo = "";
        public string competenciaId = "";
        public string indicadorId = "";
        public string genero = "F";
        public PerguntaGroup[] perguntas = null;
    }
    [System.Serializable]
    public class PerguntaGroup
    {
        public string id = "";
        public string enunciado = "";
        public int dano = 1;
        public Resposta[] opcoes = null;
        public bool ludico = false;
    }
    [System.Serializable]
    public class Resposta
    {
        public string id = "";
        public string acao = "";
        public string texto = "";
        public int pontuacao = -1;
    }

    /// <summary>
    /// Determina uma resposta que foi marcada pelo jogador, e será enviada para o servidor
    /// </summary>
    [System.Serializable]
    public class User_RespostaData
    {
        public string id;
        public string pacote_id;
        public string pergunta_id;
        public string competencia_id;
        public string indicador_id;
        public string resposta_id;
        public int intensidade;
        public float tempo_resposta;
        public bool isLudico = false;
    }
}
