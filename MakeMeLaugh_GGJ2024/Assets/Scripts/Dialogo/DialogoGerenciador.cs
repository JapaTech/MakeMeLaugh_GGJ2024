using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Dialogo;

public class DialogoGerenciador : MonoBehaviour
{
    public static DialogoGerenciador Instance;

    [SerializeField] private Canvas canvas;
    [SerializeField] private TMP_Text nome;
    [SerializeField] private TMP_Text texto;
    [SerializeField] private Image iconeAtor;

    private Conversa[] conversaAtual;
    private int mensagemAtiva = 0;

    public bool EstaTendoDialogo { get; private set; } = false;

    [SerializeField] private float velocidadeDeDigitacao = 15f;

    private Tween digitaTexto;

    private void Awake()
    {  
         Instance = this;   
    }

    public void ComecaDialogo(Conversa[] conversas)
    {
        conversaAtual = conversas;

        EstaTendoDialogo = true;

        canvas.gameObject.SetActive(true);

        mensagemAtiva = 0;

        MostrarProximaConversa();
    }

    private void MostrarProximaConversa()
    {
        Conversa conversaMostrada = conversaAtual[mensagemAtiva];

        string mensagem = "";

        nome.text = conversaAtual[mensagemAtiva].personagem.Nome;

        if(conversaAtual[mensagemAtiva].personagem.Nome == "Narrador")
        {
            iconeAtor.gameObject.SetActive(false);
        }
        else
        {
            iconeAtor.gameObject.SetActive(true);
            iconeAtor.sprite = conversaAtual[mensagemAtiva].personagem.Retrato[(int)conversaAtual[mensagemAtiva].humor];

        }


        digitaTexto = DOTween.To(() => mensagem, x => mensagem = x, conversaAtual[mensagemAtiva].messagem,
            conversaAtual[mensagemAtiva].messagem.Length / velocidadeDeDigitacao).OnUpdate(() =>
            {
                texto.text = mensagem; //conversaAtual[mensagemAtiva].messagem;

            });
    }

    public void TrocarSentenca()
    {
        mensagemAtiva++;
        if (mensagemAtiva < conversaAtual.Length)
        {
            MostrarProximaConversa();
        }
        else
        {
            FinalizarDialogo();
        }
    }

    private void FinalizarDialogo()
    {
        canvas.gameObject.SetActive(false);
        EstaTendoDialogo = false;
        Debug.Log("Dialogo acabou");
    }
}
