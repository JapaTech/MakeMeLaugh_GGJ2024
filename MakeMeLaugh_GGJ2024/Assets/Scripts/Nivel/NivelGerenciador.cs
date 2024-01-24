using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NomeCenas
{
    TestDialogueScene,
    TestGameScene
}

public class NivelGerenciador : MonoBehaviour
{
    public static NivelGerenciador Instance;

    private Canvas loadCanvas;

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

        loadCanvas = GetComponentInChildren<Canvas>();
        loadCanvas.gameObject.SetActive(false);
    }

    public void CarregaCena(NomeCenas sceneName)
    {
        StartCoroutine(EsperaCenaCarregar(sceneName.ToString()));   
    }

    private IEnumerator EsperaCenaCarregar(string sceneName)
    {
        loadCanvas.sortingOrder = 10;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        loadCanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        loadCanvas.gameObject.SetActive(false);
        loadCanvas.sortingOrder = -1;
    }

}
