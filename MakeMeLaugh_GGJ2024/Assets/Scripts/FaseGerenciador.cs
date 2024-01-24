using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cartas;
using Dialogo;
using System;

public class FaseGerenciador : MonoBehaviour
{
    [SerializeField] private CenaDeDialogo dialogoInicial;

    [SerializeField] private Image imagemDeFundo;

    [SerializeField] private GameObject cartas;

    bool teste;

    [Header("Coloque os resultados na seguite ordem, de cima para baixo: Bom, Neutro, Ruim")]
    [SerializeField] private Resultado_SO[] resultados;

    private void OnEnable()
    {
        Carta.AoClicarNaCarta += DisparaConsequencia;
    }

    private void OnDisable()
    {
        Carta.AoClicarNaCarta -= DisparaConsequencia;
    }

    private void Start()
    {
        cartas.SetActive(false);
        DialogoGerenciador.Instance.ComecaDialogo(dialogoInicial.cena);
        StartCoroutine(MostraCarta());
    }

    private IEnumerator MostraCarta()
    {
        yield return new WaitUntil(() => DialogoGerenciador.Instance.EstaTendoDialogo == false);
        cartas.SetActive(true);
    }

    private void DisparaConsequencia(TipoCarta cartaEscolhida)
    {
        /*
        switch (cartaEscolhida)
        {
            case TipoCarta.Boa:
                imagemDeFundo.sprite = resultados[0].imagemFeedback;
                break;
            case TipoCarta.Neutra:
                imagemDeFundo.sprite = resultados[1].imagemFeedback;
                break;
            case TipoCarta.Ruim:
                imagemDeFundo.sprite = resultados[2].imagemFeedback;
                break;
            default:
                Debug.Log("Carta Inválida");
                break;
        }
        */
        StartCoroutine(MostraResultado(cartaEscolhida));
    }

    private IEnumerator MostraResultado(TipoCarta cartaEscolhida)
    {
        cartas.SetActive(false);

        switch (cartaEscolhida)
        {
            case TipoCarta.Boa:
                DialogoGerenciador.Instance.ComecaDialogo(resultados[0].cenaDeDialogo.cena);
                break;
            case TipoCarta.Neutra:
                DialogoGerenciador.Instance.ComecaDialogo(resultados[1].cenaDeDialogo.cena);
                break;
            case TipoCarta.Caotica:
                DialogoGerenciador.Instance.ComecaDialogo(resultados[2].cenaDeDialogo.cena);
                break;
            default:
                Debug.Log("Carta Inválida");
                break;
        }
        yield return new WaitUntil(() => DialogoGerenciador.Instance.EstaTendoDialogo == false);

        switch (cartaEscolhida)
        {
            case TipoCarta.Boa:
                imagemDeFundo.sprite = resultados[0].imagemFeedback;
                break;
            case TipoCarta.Neutra:
                imagemDeFundo.sprite = resultados[1].imagemFeedback;
                break;
            case TipoCarta.Caotica:
                imagemDeFundo.sprite = resultados[2].imagemFeedback;
                break;
            default:
                Debug.Log("Carta Inválida");
                break;
        }
    }
}
