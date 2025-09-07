using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private ItemEffectBase currentitem;

    public void UseItem(PlayerController controller)
    {
        if (currentitem == null) return;

        ItemEffectVisitor visitor = new ItemEffectVisitor(controller);
        currentitem.Accept(visitor);
        currentitem = null; 
    }
}
