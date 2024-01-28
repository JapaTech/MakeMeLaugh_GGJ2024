using UnityEngine;
using FMODUnity;

public class FMODEventsData : MonoBehaviour
{
   public static FMODEventsData Instance;

    [field: Header("Botao Avancar")]
    [field: SerializeField] public EventReference BotaoClick { get; private set; }

    [field: Header("Musica Intro")]
    [field: SerializeField] public EventReference MusicaIntro { get; private set; }

    [field: Header("Musica  Gameplay")]
    [field: SerializeField] public EventReference MusicaGameplay { get; private set; }

    [field: Header("Musica  Creditos")]
    [field: SerializeField] public EventReference MusicaCreditos { get; private set; }

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
}
