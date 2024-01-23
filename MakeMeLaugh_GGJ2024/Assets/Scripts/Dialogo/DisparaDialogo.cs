using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogo
{
    public class DisparaDialogo : MonoBehaviour
    {
        public CenaDeDialogo[] cenas;

        private void Start()
        {
            DialogoGerenciador.Instance.ComecaDialogo(cenas[0].cena);
        }
    }
}

