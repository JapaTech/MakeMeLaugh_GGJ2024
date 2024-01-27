using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NomeCenas
{
    MenuInicial,
    Fase_1,
    Fase_2,
    Fase_3,
    Fase_4,
    Fase_5,
    Final,
    Creditos
}

public class NivelGerenciador : MonoBehaviour
{
    public static NivelGerenciador Instance;

    [SerializeField] private float duracaoFadeIn;
    [SerializeField] private float duracaoFadeOut;
    [SerializeField] private float tempoEspera;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);

        /*
        loadCanvas = GetComponentInChildren<Canvas>();
        loadCanvas.gameObject.SetActive(false);
        */
    }

    public void CarregaCena(NomeCenas sceneName)
    {
        StartCoroutine(EsperaCenaCarregar(sceneName.ToString(), duracaoFadeIn, tempoEspera, duracaoFadeOut));   
    }

    private IEnumerator EsperaCenaCarregar(string sceneName, float duracaoFadeIn, float tempoEspera, float duracaoFadeOut)
    {
        yield return Fade.Instance.ExecutaFade(duracaoFadeIn, Color.clear, Color.black, true);
       ;
        yield return new WaitWhile(() => Fade.EstaTransicionando);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);


        yield return new WaitWhile(() => !asyncLoad.isDone);

        yield return new WaitForSeconds(tempoEspera);


        yield return Fade.Instance.ExecutaFade(duracaoFadeOut, Color.black, Color.clear, false);
        

    }

}
