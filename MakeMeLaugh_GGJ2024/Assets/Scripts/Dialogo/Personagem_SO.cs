using UnityEngine;

public enum Humor
{
    Padrao,
    Feliz,
    Triste
}

namespace Dialogo
{
    [CreateAssetMenu(menuName = "Dialogo/Personagem", fileName = "Personagem")]
    public class Personagem_SO : ScriptableObject
    {
        public string Id;
        public string Nome;
        public Sprite[] Retrato;
        
    }
    
}

