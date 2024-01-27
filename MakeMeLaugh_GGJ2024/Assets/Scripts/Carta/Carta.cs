using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Cartas
{
    public enum TipoCarta
    {
        Boa,
        Ruim,
        Caotica
    }

    [RequireComponent(typeof(Button))]
    public class Carta : MonoBehaviour
    {
        public static Action<TipoCarta> AoClicarNaCarta;


        [SerializeField] private Carta_SO cartaDados;

        private Button corpo;
        private TMP_Text titulo;
        [SerializeField] private Image icone;
        [SerializeField] private Image imagemCarta;

        [SerializeField] private TipoCarta tipoCarta;

        private void Start()
        {
            corpo = GetComponent<Button>();
            titulo = GetComponentInChildren<TMP_Text>();

            imagemCarta.sprite = cartaDados.DesenoImg;
            titulo.text = cartaDados.Titulo;
            icone.sprite = cartaDados.IconeImg;
        }

        public void ClicouNaCarta()
        {
            AoClicarNaCarta?.Invoke(tipoCarta);
            FinaisGerenciador.RecebeEscolha(tipoCarta);
        }
    }

}
