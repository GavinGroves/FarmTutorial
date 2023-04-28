using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        //拿到对数据的控制
        [Header("物品数据")] public ItemDataList_SO itemDataList_So;

        [Header("背包数据")] public InventoryBag_SO playerBag;

        private void Start()
        {
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player,playerBag.itemList);
        }

        /// <summary>
        /// 通过ID返回物品信息
        /// </summary>
        public ItemDetails GetItemDetails(int ID)
        {
            return itemDataList_So.itemDetailsList.Find(i => i.itemID == ID);
        }

        /// <summary>
        /// 添加物品到Player背包里
        /// </summary>
        /// <param name="item"></param>
        /// <param name="toDestory">是否要销毁物品</param>
        public void AddItem(Item item, bool toDestory)
        {
            //背包是否已经存在该物品
            int index = GetItemIndexInBag(item.itemID);
            
            AddItemAtIndex(item.itemID,index,1);

            Debug.Log(GetItemDetails(item.itemID).itemID + "Name:" + GetItemDetails(item.itemID).itemName);
            if (toDestory)
            {
                Destroy(item.gameObject);
            }
            
            //更新UI
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player,playerBag.itemList);
        }

        /// <summary>
        /// 检查背包是否有空位
        /// </summary>
        private bool CheckBagCapacity()
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == 0)
                    return true;
 
            }

            return false;
        }

        /// <summary>
        /// 通过物品ID找到背包已有物品的位置
        /// </summary>
        /// <param name="ID">物品ID</param>
        /// <returns>-1则没有这个物品否则返回序号</returns>
        private int GetItemIndexInBag(int ID)
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == ID)
                    return i;

            }

            return -1;
        }

        /// <summary>
        /// 在指定背包序号位置添加物品
        /// </summary>
        /// <param name="ID">物品ID</param>
        /// <param name="index">序号</param>
        /// <param name="amount">数量</param>
        private void AddItemAtIndex(int ID, int index, int amount)
        {
            if (index == -1 && CheckBagCapacity()) //背包没有这个物品并且有容量
            {
                //直接初始化,添加这个物品
                var item = new InventoryItem { itemID = ID, itemAmount = amount };
                //循环，找到空格子，Item放进去
                for (int i = 0; i < playerBag.itemList.Count; i++)
                {
                    if (playerBag.itemList[i].itemID == 0)
                    {
                        playerBag.itemList[i] = item;
                        break;
                    }
                }
            }
            else //背包有这个物品
            {
                //有就找到那个物品+加上数量
                int currentAmount = playerBag.itemList[index].itemAmount + amount;
                var item = new InventoryItem { itemID = ID, itemAmount = currentAmount };

                playerBag.itemList[index] = item;
            }
        }
    }
}