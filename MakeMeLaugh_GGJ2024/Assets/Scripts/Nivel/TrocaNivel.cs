using UnityEngine;

public class TrocaNivel : MonoBehaviour
{
    [SerializeField] private NomeCenas nomeCena;

    public void VaiParaNovaCena()
    {
        NivelGerenciador.Instance.CarregaCena(nomeCena);
    }
}
