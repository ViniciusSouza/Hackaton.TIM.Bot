using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using BestHTTP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Talent
{
    /// <summary>
    /// Contem todas as chamadas e callbacks de interacoes com o backend
    /// </summary>
    public class WebRequestsManager : MonoBehaviour
    {
        /// <summary>
        /// Retorna um callback de login OU um de erro
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="error"></param>
        public delegate void OnLogin(Network.LoginSignData callback, Network.Error error);
        public event OnLogin Evt_OnLogin;
        public event OnLogin Evt_OnSignUp;

        public delegate void OnSaveData(Network.BasicObjectData callback, Network.Error error);
        public event OnSaveData Evt_OnCreateSaveData;
        public event OnSaveData Evt_OnUpdateSaveData;

        public delegate void OnGetSaveData(Network.SavedData callback, Network.Error error);
        public event OnGetSaveData Evt_OnGetSaveData;

        public delegate void OnGetModuleData(Network.ModulePackData callback, Network.Error error);
        public event OnGetModuleData Evt_OnGetModuleData;

        public delegate void OnUpdatePassword(Network.Error error);
        public event OnUpdatePassword Evt_OnUpdatePassword;

        private static WebRequestsManager instance = null;
        public static WebRequestsManager Instance
        {
            get
            {
                return instance;
            }
        }
        public const string CLIENTE = "raizen";
        public const string URL_DOMINIO = "https://tm-backend-api.azurewebsites.net/";
        //public const string URL_DOMINIO = "http://localhost:3001/";
        public const string URL_SIGNUP = "{0}/signup";

        /// <summary>
        /// Armazena os dados desse usuario referente ao banco de dados, como ID unico e ID do salvamento
        /// Facilita o acesso e vinculo do usuario ao banco de dados
        /// </summary>
        public Network.LoginSignData loginData = new Network.LoginSignData();

        #region Error Treatment
        /// <summary>
        /// Qualquer chamada que seja feita corretamente retorna 200 como código
        /// </summary>
        public List<int> OK_CODE = new List<int>() { 200, 304, 666 };

        private int errorCount = 0;
        /// <summary>
        /// Maximo de erros de request de salvamento tolerados antes de mostrar aviso na tela
        /// </summary>
        public const int MAX_ERROR_COUNT = 5;

        /// <summary>
        /// Objeto contendo popup de erro de network que evita que o jogador continue em caso de erros de network
        /// </summary>
        public GameObject prefabFatalError;
        #endregion

        /// <summary>
        /// Nome da chave do player prefs que gera os backups
        /// </summary>
        public const string BACKUP_KEY = "backup_web";

        void Awake()
        {
            if (WebRequestsManager.instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        public string GetSHA256String(string unhashed)
        {
            //Debug.Log("Generating SHA256 hash value from: \"" + unhashed + "\"");
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(unhashed);
            System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] hash = sha256.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// Seta headers de um request
        /// </summary>
        /// <param name="request"></param>
        public void SetDefaultHeaders(ref HTTPRequest request)
        {
            request.AddHeader("Content-Type", "application/json");
        }
        /// <summary>
        /// Adiciona o header de token de usuario atual para chamadas que precisam
        /// </summary>
        /// <param name="request"></param>
        public void AddUserHeader(ref HTTPRequest request)
        {
            request.AddHeader("x-access-token", loginData.token);
        }
        /// <summary>
        /// Faz chamada POST
        /// </summary>
        /// <param name="json"></param>
        /// <param name="callback"></param>
        private void DoPOST(string url, string json, OnRequestFinishedDelegate callback, bool addUserHeader = false)
        {
            HTTPRequest request = new HTTPRequest(new Uri(url), HTTPMethods.Post, callback);
            SetDefaultHeaders(ref request);
            if (addUserHeader)
                AddUserHeader(ref request);
            request.RawData = Encoding.UTF8.GetBytes(json);
            request.Send();
        }
        /// <summary>
        /// Faz chamada GET
        /// </summary>
        /// <param name="url"></param>
        /// <param name="callback"></param>
        private void DoGET(string url, OnRequestFinishedDelegate callback, bool addUserHeader = false)
        {
            HTTPRequest request = new HTTPRequest(new Uri(url), HTTPMethods.Get, callback);
            SetDefaultHeaders(ref request);
            if (addUserHeader)
                AddUserHeader(ref request);
            request.Send();
        }
        /// <summary>
        /// Faz chamada POST
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="callback"></param>
        private void DoPUT(string url, string json, OnRequestFinishedDelegate callback, bool addUserHeader = false)
        {
            HTTPRequest request = new HTTPRequest(new Uri(url), HTTPMethods.Put, callback);
            SetDefaultHeaders(ref request);
            if (addUserHeader)
                AddUserHeader(ref request);
            request.RawData = Encoding.UTF8.GetBytes(json);
            Debug.Log(url);
            request.Send();
        }
        /// <summary>
        /// Retorna se um response apresenta erro ou nao
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public bool ResponseHaveErrors(HTTPResponse response)
        {
            if (OK_CODE.Contains(response.StatusCode) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Faz a checagem de uma resposta http para determinar se tem erros no callback ou nao
        /// </summary>
        /// <param name="response"></param>
        /// <returns>Nulo caso não haja erros</returns>
        public Network.Error GetResponseErrors(HTTPResponse response)
        {
            if (OK_CODE.Contains(response.StatusCode) == false)
            {
                Network.Error error = new Network.Error();
                if(response.DataAsText.Trim() != "")
                    error = JsonConvert.DeserializeObject<Network.Error>(response.DataAsText);
                error.code = response.StatusCode;
                return error;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Retorna um conjunto de urls combinado e qulaquer campo {0} substituido pelo user atual (id)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="urls"></param>
        /// <returns></returns>
        private string GetFormattedUrl(string path, string user = "")
        {
            return (URL_DOMINIO + (string.Format(path, CLIENTE, user)));
        }
        /// <summary>
        /// Caso ocorra um erro, tenta reenviar um request ate um certo limite de vezes
        /// </summary>
        /// <param name="request"></param>
        public void ErrorOccurred(HTTPRequest request)
        {
            errorCount++;
            if (errorCount >= MAX_ERROR_COUNT)
            {
                //Instancia o popup de erro
                GameObject fatal = (GameObject)Instantiate(prefabFatalError);
                DontDestroyOnLoad(fatal);
                //Volta para a tela inicial
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                //Faz o reenvio
                request.Send();
            }
        }
        /// <summary>
        /// Reseta o contador de erro
        /// </summary>
        public void ResetErrorCount()
        {
            errorCount = 0;
        }

        /// <summary>
        /// Faz cadastro do jogador
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void SignUp(string name, string email, string password, string genero, string nascimento)
        {
            var jo = new JObject();
            jo.Add("nome", name);
            jo.Add("email", email);
            jo.Add("genero", genero);
            jo.Add("dataNascimento", nascimento);
            jo.Add("password", GetSHA256String(password));
            string json = jo.ToString();

            DoPOST(GetFormattedUrl(URL_SIGNUP), json, OnSignUpCallback);
        }
        private void OnSignUpCallback(HTTPRequest request, HTTPResponse response)
        {
            // Check for null errors:
            if (response == null)
            {
                Network.Error nullError = new Network.Error();
                nullError.code = 404;
                nullError.erro = request.Exception.Message;

                if (Evt_OnSignUp != null)
                    Evt_OnSignUp(null, nullError);
                return;
            }

            string dataAsText = response.DataAsText;
            Debug.Log("SignUp terminado! Text received: " + dataAsText);

            //Determina se ocorreu erro ou nao
            if (ResponseHaveErrors(response)) 
            {
                if (Evt_OnSignUp != null)
                    Evt_OnSignUp(null, GetResponseErrors(response));
            }
            else
            {
                loginData = JsonConvert.DeserializeObject<Network.LoginSignData>(dataAsText);
                loginData.code = response.StatusCode;
                if (Evt_OnSignUp != null)
                    Evt_OnSignUp(loginData, null);
            }
        }
        /// <summary>
        /// Faz request de um pacote via chamada de missão diaria
        /// </summary>
        public void GetDailyMissionPack()
        {
            DoGET(GetFormattedUrl("", loginData.id), OnGetModulePackCallback, true);
        }
        /// <summary>
        /// Callback de qualquer request de modulo com pactoe padrao
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        private void OnGetModulePackCallback(HTTPRequest request, HTTPResponse response)
        {
            // Check for null errors:
            if (response == null)
            {
                Network.Error nullError = new Network.Error();
                nullError.code = 404;
                nullError.erro = request.Exception.Message;
                Debug.Log(nullError.erro);

                ErrorOccurred(request);

                return;
            }

            string dataAsText = response.DataAsText;
            Debug.Log("Get de modulo terminado! Text received: " + dataAsText);
            //Determina se ocorreu erro ou nao
            if (ResponseHaveErrors(response))
            {
                ErrorOccurred(request);
                /*if (Evt_OnGetModuleData != null)
                    Evt_OnGetModuleData(null, GetResponseErrors(response));
                */
            }
            else
            {
                ResetErrorCount();

                if (Evt_OnGetModuleData != null)
                    Evt_OnGetModuleData(JsonConvert.DeserializeObject<Network.ModulePackData>(dataAsText), null);
            }
        }
    }
}