using UnityEngine;

[CreateAssetMenu(menuName ="Dialogo/Personagem", fileName = "Personagem")]
public class Personagem_SO : ScriptableObject
{
    public string id;
    public string pome;
    public Sprite[] retrato;
    public Humor humor;
}

public enum Humor
{
    Padrao,
    Feliz,
    Triste
}