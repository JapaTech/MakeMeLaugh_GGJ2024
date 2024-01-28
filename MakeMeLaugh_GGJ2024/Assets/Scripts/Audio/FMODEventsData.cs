using UnityEngine;
using FMODUnity;

public class FMODEventsData : MonoBehaviour
{
    public static FMODEventsData Instance;

   [field: Header("Botao Avancar")]
   [field: SerializeField] public EventReference BotaoClick { get; private set; }

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
