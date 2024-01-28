using UnityEngine;

public class MenuInicial : MenuInGame
{
    protected override void Start()
    {
        FinaisGerenciador.ResetaValores();
        DesativaPainelSair();

        FMODAudioGerenciador.Instance.LimparEventos();
        FMODAudioGerenciador.Instance.PararMusicas();
        FMODAudioGerenciador.Instance.IniciarMusicaIntro(FMODEventsData.Instance.MusicaIntro);
    }


    public void Sair()
    {
        Application.Quit();
    }
}
