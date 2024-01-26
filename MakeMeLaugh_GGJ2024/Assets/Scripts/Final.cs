using UnityEngine;
using UnityEngine.UI;
using Dialogo;

public class Final : MonoBehaviour
{
    [SerializeField] private Image imagemFinal;

    [SerializeField] private Resultado_SO[] finais;
    
    [SerializeField] private TrocaNivel avancaNivel;

    private void Start()
    {
        Finais fim = FinaisGerenciador.VaiParaCenaFinal();

        switch (fim)
        {
            case Finais.Bom:
                imagemFinal.sprite = finais[0].imagemFeedback;
                DialogoGerenciador.Instance.ComecaDialogo(finais[0].cenaDeDialogo.cena);
                break;
            case Finais.Ruim:
                imagemFinal.sprite = finais[1].imagemFeedback;
                DialogoGerenciador.Instance.ComecaDialogo(finais[1].cenaDeDialogo.cena);
                break;
            case Finais.Caotico:
                imagemFinal.sprite = finais[2].imagemFeedback;
                DialogoGerenciador.Instance.ComecaDialogo(finais[2].cenaDeDialogo.cena);
                break;
            default:
                break;
        }
    }
}
