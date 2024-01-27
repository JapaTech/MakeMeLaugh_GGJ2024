using UnityEngine;
using UnityEngine.SceneManagement;
using Cartas;

public enum Finais
{
    Bom,
    Ruim,
    Caotico
}

public class FinaisGerenciador : MonoBehaviour
{
    public static FinaisGerenciador Instance;

    public static int escolhaBoa = 0;
    public static int escolhaRuim = 0;
    public static int escolhaCaotica = 0;

    private static NomeCenas penultimaCena = NomeCenas.Fase_5;
    private static TipoCarta tipo;

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
    

    public static void RecebeEscolha(TipoCarta tipoCarta)
    {
        switch (tipoCarta)
        {
            case TipoCarta.Boa:
                escolhaBoa++;
                break;
            case TipoCarta.Ruim:
                escolhaRuim++;
                break;
            case TipoCarta.Caotica:
                escolhaCaotica++;
                break;
            default:
                Debug.Log("Escolha inválida");
                break;
        }
        Debug.Log("Subiu");

        if (SceneManager.GetActiveScene().name == penultimaCena.ToString())
        {
            tipo = tipoCarta;
        }
    }

 
    public static Finais VaiParaCenaFinal()
    {
        if(escolhaBoa > escolhaRuim && escolhaBoa > escolhaCaotica)
        {
            //Codigo para trocar a cena para o final bom
            return Finais.Bom;
        }
        else if (escolhaRuim > escolhaBoa && escolhaRuim > escolhaCaotica)
        {
            //Codigo para trocar a cena para o final neutro
            return Finais.Ruim;
        }
        else if (escolhaCaotica > escolhaBoa && escolhaCaotica > escolhaRuim)
        {
            //Codigo para trocar a cena para o final caotico
            return Finais.Caotico;
        }
        else if (tipo == TipoCarta.Boa)
        {
            Debug.Log("Final Bom");
            return Finais.Bom;
        }
        else if (tipo == TipoCarta.Ruim)
        {
            Debug.Log("Final Ruim");
            return Finais.Ruim;
        }
        else if (tipo == TipoCarta.Caotica)
        {
            Debug.Log("Final Caotico");
            return Finais.Caotico;
        }
        else
        {
            Debug.Log("Algo deu muito errado");
            return Finais.Bom;
        }
    }

    public static void ResetaValores()
    {
        escolhaBoa = 0;
        escolhaRuim = 0;
        escolhaCaotica = 0;
    }

}
