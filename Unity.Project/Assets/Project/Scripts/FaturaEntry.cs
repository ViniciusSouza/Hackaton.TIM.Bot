using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaturaEntry : MonoBehaviour {

    public Text txtDate;
    public Text txtTime;
    public Text txtDescription;
    public Text txtSaldo;
    public Text txtValor;

    public GameObject objLigacao;
    public GameObject objDados;

    public Text txtDuracao;
    public Text txtMbReceived;
    public Text txtMbSent;

    public void SetEntry(Detalhes detalhes)
    {
        System.DateTime date = DateTime.ParseExact(detalhes.DataHora, "yyyy-MM-ddTHH:mm:ssZ",
                                       System.Globalization.CultureInfo.InvariantCulture);
        txtDate.text = date.Date.ToString();
        txtTime.text = date.ToShortTimeString();

        txtDescription.text = detalhes.Descricao;
        txtSaldo.text = "R$" + detalhes.Saldo;
        txtValor.text = "R$" + detalhes.Valor;

        //Ligacao
        if (detalhes.Tipo == 0)
        {
            objLigacao.SetActive(true);
            txtDuracao.text = detalhes.Duracao;
        }
        else if (detalhes.Tipo == 1)
        {
            objDados.SetActive(true);
            txtMbReceived.text = detalhes.MBytesRecebidos;
            txtMbSent.text = detalhes.MbytesEnviados;
        }
    }
}
