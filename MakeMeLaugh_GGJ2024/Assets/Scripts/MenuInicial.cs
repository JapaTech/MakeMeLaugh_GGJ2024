using UnityEngine;

public class MenuInicial : MenuInGame
{

    protected override void Start()
    {
        FinaisGerenciador.ResetaValores();
        DesativaPainelSair();
    }


    public void Sair()
    {
        Application.Quit();
    }
}
