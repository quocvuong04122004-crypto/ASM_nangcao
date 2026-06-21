using UnityEngine;

public enum ItemType
{
    Resource,
    Food,
    Tool,
    Building
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public ItemType itemType;

    public bool stackable = true;
    public int maxStack = 99;

    public GameObject handPrefab;
}