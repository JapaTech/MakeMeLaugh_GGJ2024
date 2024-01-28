using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DelayButton : MonoBehaviour
{
    private Button esperaUmTempo;


    private void Awake()
    {
        esperaUmTempo = GetComponent<Button>();
        
    }

    private void OnEnable()
    {
        
        esperaUmTempo.interactable = true;
    }

    private void Start()
    {
    }

    public void ComecaDelay()
    {
        esperaUmTempo.interactable = false;
        if(gameObject.activeInHierarchy)
            StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        esperaUmTempo.interactable = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
