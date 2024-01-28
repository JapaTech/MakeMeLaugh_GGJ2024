using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODAudioGerenciador : MonoBehaviour
{
    public static FMODAudioGerenciador Instance;

    private List<EventInstance> eventosDeInstancaia = new List<EventInstance>();

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
