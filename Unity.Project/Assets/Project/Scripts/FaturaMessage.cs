using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaturaMessage : MonoBehaviour {

    public Text txtSaldoAtual;
    public Text txtLastRecarga;
    public Text txtLastRecargaDate;

    public GameObject prefabEntrySaldo;

    public Transform container;

    /// <summary>
    /// Organiza e exibe a informacao de detalhamento de conta
    /// </summary>
    /// <param name="message"></param>
    /// <param name="fatura"></param>
    public void SetMessage(ConversationWindow _window, string message, Content fatura)
    {
        //O saldo atual é sempre a ultima entrada da lista
        txtSaldoAtual.text = "R$" + fatura.Detalhes[fatura.Detalhes.Count - 1].Saldo;
        txtLastRecarga.text = "";
        txtLastRecargaDate.text = "";

        //Procura qunado foi a ultima recarga
        for (int x = fatura.Detalhes.Count - 1; x >= 0; x--)
        {
            if (fatura.Detalhes[x].Tipo == 2)
            {
                txtLastRecarga.text = fatura.Detalhes[x].Valor;
                txtLastRecargaDate.text = fatura.Detalhes[x].DataHora;
                break;
            }
        }

        //Agora cria todas entradas da conta
        for (int x = 0; x < fatura.Detalhes.Count; x++)
        {
            GameObject g = (GameObject)Instantiate(prefabEntrySaldo, container);
            g.transform.localPosition = Vector3.zero;
            g.transform.localScale = Vector3.one;
            g.transform.localRotation = Quaternion.identity;

            g.GetComponent<FaturaEntry>().SetEntry(fatura.Detalhes[x]);
        }
    }
}
