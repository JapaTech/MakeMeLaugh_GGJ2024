using UnityEngine;
using UnityEngine.SceneManagement;
using Cartas;

public class FinaisGerenciador : MonoBehaviour
{
    public static FinaisGerenciador Instance;

    private int escolhaBoa = 0;
    private int escolhaNeutra = 0;
    private int escolhaCaotica = 0;

    private bool EstaNaCenaFinal = false;


    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        Carta.AoClicarNaCarta += RecebeEscolha;
    }

    private void OnDisable()
    {
        Carta.AoClicarNaCarta -= RecebeEscolha;
    }

    private void RecebeEscolha(TipoCarta tipoCarta)
    {
        switch (tipoCarta)
        {
            case TipoCarta.Boa:
                escolhaBoa++;
                break;
            case TipoCarta.Neutra:
                escolhaNeutra++;
                break;
            case TipoCarta.Caotica:
                escolhaCaotica++;
                break;
            default:
                Debug.Log("Escolha inválida");
                break;
        }
    }

    public void VerificaSeECenaFinal(string nomeCena)
    {
        if (nomeCena == NomeCenas.TestGameScene.ToString())
        {
            EstaNaCenaFinal = true;
        }
    }

    private void VaiParaCenaFinal()
    {
        if(escolhaBoa > escolhaNeutra && escolhaBoa > escolhaCaotica)
        {
            //Codigo para trocar a cena para o final bom
            Debug.Log("Final bom");
        }
        else if (escolhaNeutra > escolhaBoa && escolhaNeutra > escolhaCaotica)
        {
            //Codigo para trocar a cena para o final neutro
            Debug.Log("Final neutro");
        }
        else if (escolhaCaotica > escolhaBoa && escolhaCaotica > escolhaNeutra)
        {
            //Codigo para trocar a cena para o final caotico
            Debug.Log("Final caótico");
        }
    }
}
