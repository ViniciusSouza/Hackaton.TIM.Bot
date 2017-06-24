using System.Collections.Generic;

[System.Serializable]
public class Content
{
    public string content = "";
    public List<Buttons> buttons = new List<Buttons>();
    public string Nome = "";
    public string CPF = "";
    public string DataNascimento = "";
    public List<Detalhes> Detalhes = new List<Detalhes>();
}

[System.Serializable]
public class Detalhes
{
    public int Tipo = 0;
    public string Descricao = "";
    public string DataHora = "";
    public string Duracao = "";
    public string Valor = "";
    public string Saldo = "";
    public string MbytesEnviados = "";
    public string MBytesRecebidos = "";
}

[System.Serializable]
public class Buttons
{
    public string type = "";
    public string title = "";
    public string value = "";
}

[System.Serializable]
public class Attachment {

    public string contentType = "";
    public List<Content> content = new List<Content>();
}
