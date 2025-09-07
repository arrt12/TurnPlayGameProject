using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class Item : ScriptableObject
{
    [Header("������ �̸�")]
    public string itemName;

    [Header("������ �̹���")]
    public Sprite itemImage;

    [Multiline]
    [Header("������ ����")]
    public string itemMethod;
}
