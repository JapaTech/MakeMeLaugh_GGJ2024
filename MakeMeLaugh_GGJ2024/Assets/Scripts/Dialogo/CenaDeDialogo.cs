using UnityEngine;

namespace Dialogo
{
    [CreateAssetMenu(menuName = "Dialogo/Cena", fileName = "Cena")]
    
    public class CenaDeDialogo : ScriptableObject
    {
        public Conversa[] cena;
    }

    [System.Serializable]
    public class Conversa
    {
        [field: TextArea(3, 20)]
        public string messagem;
        public Personagem_SO personagem;
        public Humor humor;
    }

}

