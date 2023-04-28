using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class ItemPickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Item item = col.GetComponent<Item>();
            if (item != null)
            {
                if (item.m_ItemDetails.canPickedUp)
                {
                    //拾起物品放进背包
                    InventoryManager.Instance.AddItem(item, true);
                }
            }
        }
    }
}