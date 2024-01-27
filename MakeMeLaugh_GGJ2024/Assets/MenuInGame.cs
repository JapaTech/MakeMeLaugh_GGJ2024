using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private GameObject painelSair;

    protected virtual void Start()
    {
        DesativaPainelSair();
    }

    public void AtivaPainelSair()
    {
        painelSair.SetActive(true);

    }

    public void DesativaPainelSair()
    {
        painelSair.SetActive(false);
    }
    
}
