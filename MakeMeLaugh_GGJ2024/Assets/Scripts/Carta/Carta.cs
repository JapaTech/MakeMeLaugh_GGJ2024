using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button), typeof(Carta_SO))]
public class Carta : MonoBehaviour
{
    public static Action<int> AoClicarNaCarta;

    public enum TipoCarta
    {
        Boa,
        Neutra,
        Ruim
    }

    [SerializeField] private Carta_SO cartaDados;
    
    private Button corpo;
    private TMP_Text titulo;
    private Image icone;

    [SerializeField] private TipoCarta tipoCarta;

    private void Start()
    {
        corpo = GetComponent<Button>();
        titulo = GetComponentInChildren<TMP_Text>();
        icone = GetComponentInChildren<Image>();
        
        corpo.image.sprite = cartaDados.BgImg;
        titulo.text = cartaDados.Titulo;
        icone.sprite = cartaDados.IconeImg;
    }

    public void ClicouNaCarta()
    {
        AoClicarNaCarta?.Invoke((int) tipoCarta);
    }
}
