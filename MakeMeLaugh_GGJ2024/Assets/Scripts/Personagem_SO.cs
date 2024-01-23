using UnityEngine;

namespace Dialogo
{
    [CreateAssetMenu(menuName = "Dialogo/Personagem", fileName = "Personagem")]
    public class Personagem_SO : ScriptableObject
    {
        public string id;
        public string nome;
        public Sprite[] retrato;
        public Humor humor;
    }

    public enum Humor
    {
        Padrao,
        Feliz,
        Triste
    }
}

