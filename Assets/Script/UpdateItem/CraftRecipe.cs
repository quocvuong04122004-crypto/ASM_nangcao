using UnityEngine;

[CreateAssetMenu(menuName = "Craft/Recipe")]
public class CraftRecipe : ScriptableObject
{
    public ItemData inputA;
    public int amountA = 1;

    public ItemData inputB;
    public int amountB = 1;

    public ItemData output;
}