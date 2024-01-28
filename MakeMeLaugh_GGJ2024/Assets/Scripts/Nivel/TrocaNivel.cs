using UnityEngine;

public class TrocaNivel : MonoBehaviour
{
    [SerializeField] private NomeCenas nomeCena;

    public void VaiParaNovaCena()
    {
        FMODAudioGerenciador.Instance.LimparEventos();
        NivelGerenciador.Instance.CarregaCena(nomeCena);
    }
}
