using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// fileName 表示数据资源文件创建出来的文件名
// menuName 表示在菜单 Assets/Create 下的名字
[CreateAssetMenu(fileName = "ItemDataList_SO",menuName = "Inventory/ItemDataList")]
public class ItemDataList_SO : ScriptableObject
{
    //物品数据类通过List存储调用
    public List<ItemDetails> itemDetailsList;
}