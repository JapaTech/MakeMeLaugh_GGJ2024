using System.Collections;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private Dialogo.CenaDeDialogo dialogoInicial;
    [SerializeField] private GameObject Instrucoes;
    [SerializeField] private Cartas.Carta carta;
    
    void Start()
    {
        Instrucoes.SetActive(false);
        carta.gameObject.SetActive(false);
        StartCoroutine(Tutorial());
    }

    private IEnumerator Tutorial()
    {
        DialogoGerenciador.Instance.ComecaDialogo(dialogoInicial.cena);
        yield return new WaitUntil(() => DialogoGerenciador.Instance.EstaTendoDialogo == false);
        carta.gameObject.SetActive(true);
        Instrucoes.SetActive(true);
    }
}