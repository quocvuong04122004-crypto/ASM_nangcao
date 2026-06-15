using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "SurvivalGame/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public GameObject dropPrefab; // Mô hình 3D rớt ra trên mặt đất
    public Sprite icon; // Hình ảnh hiển thị trong túi đồ
} 