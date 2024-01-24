using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public static Fade Instance;

    private Canvas canvasFade;
    private Image imagemSobreposicao;
    private static bool estaTransicionando;
    public static bool EstaTransicionando => estaTransicionando;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        canvasFade = GetComponent<Canvas>();
    }

  

    public Coroutine IniciaCorrotinaFade(float duracao, Color corInicial, Color corFinal)
    {
         return StartCoroutine(ExecutaFade(duracao, corInicial, corInicial, true));
    }

    public IEnumerator ExecutaFade(float duracao, Color corInicial, Color corFinal, bool eFadeOut)
    {
        WaitForEndOfFrame fimDoFrame = new WaitForEndOfFrame();

        if(imagemSobreposicao == null)
        {
            CriaImagem();
        }
        imagemSobreposicao.gameObject.SetActive(true);

        estaTransicionando = true;
        float tempoPassado = 0;

        while (tempoPassado < duracao)
        {
            imagemSobreposicao.color = Color.Lerp(corInicial, corFinal, tempoPassado/duracao);
            tempoPassado += Time.deltaTime;
            yield return fimDoFrame;
        }
        estaTransicionando = false;

        if(!eFadeOut)
        {
            imagemSobreposicao.gameObject.SetActive(false);
        }
    }

    private void CriaImagem()
    {
        canvasFade.sortingOrder = 100;

        GameObject imagemTransicao = new GameObject("ImagemTransicao");

        imagemSobreposicao = imagemTransicao.AddComponent<Image>();
        
        imagemTransicao.transform.SetParent(canvasFade.transform);

        RectTransform rctImagem = imagemTransicao.GetComponent<RectTransform>();
        rctImagem.anchorMin = Vector2.zero;
        rctImagem.anchorMax = Vector2.one;
        rctImagem.localPosition = Vector3.zero;
        rctImagem.sizeDelta = Vector2.zero;
    }
}
