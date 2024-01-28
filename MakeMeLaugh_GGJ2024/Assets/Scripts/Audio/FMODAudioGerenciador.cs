using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODAudioGerenciador : MonoBehaviour
{
    public static FMODAudioGerenciador Instance;

    private List<EventInstance> eventosDeInstancaia = new List<EventInstance>();

    private EventInstance musicaIntro;
    private EventInstance musicaGameplay;
    private EventInstance musicaCreditos;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void IniciarMusicaGameplay(EventReference _musicaGameplay)
    {
        musicaGameplay = CriarInstanciaDeEvento(_musicaGameplay);
        musicaGameplay.start();
    }

    public void IniciarMusicaIntro(EventReference _musicaIntro)
    {
        musicaIntro = CriarInstanciaDeEvento(_musicaIntro);
        musicaIntro.start();
    }

    public void IniciarMusicaCreditos(EventReference _musicaCreditos)
    {
        musicaCreditos = CriarInstanciaDeEvento(_musicaCreditos);
        musicaCreditos.start();
    }

    public void PararMusicas()
    {
        musicaGameplay.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicaIntro.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicaCreditos.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


    //Tocar evento sonoro 2D
    public void PlayOneShot(EventReference eventoSonoro)
    {
        RuntimeManager.PlayOneShot(eventoSonoro);
    }

    //Sobrecarga para tocar evento sonoro 3D
    public void PlayOneShot(EventReference eventoSonoro, Vector3 posicao)
    {
        RuntimeManager.PlayOneShot(eventoSonoro, posicao);
    }


    public EventInstance CriarInstanciaDeEvento(EventReference e)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(e);
        return eventInstance;
    }

    public void LimparEventos()
    {
        foreach (EventInstance e  in eventosDeInstancaia)
        {
            e.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            e.release();
        }
    }

    private void OnDestroy()
    {
        LimparEventos();
    }
}
