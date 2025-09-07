using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class Item : ScriptableObject
{
    [Header("아이템 이름")]
    public string itemName;

    [Header("아이템 이미지")]
    public Sprite itemImage;

    [Multiline]
    [Header("아이템 설명")]
    public string itemMethod;
}
