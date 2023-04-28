using UnityEngine;

//unity可视化
[System.Serializable]
//物品信息类
public class ItemDetails
{
    public int itemID; //id
    public string itemName; //物品名字
    public ItemType itemType; //物品类型
    public Sprite itemIcon; //物品图标
    public Sprite itemOnWorldSprite; //地图场景显示的图标
    public string itemDescription; //物品详情
    public int itemUseRadius; //物品使用范围
    public bool canPickedUp; //能否捡起
    public bool canDropped; //能否扔在地上
    public bool canCarried; //能否拾取
    public int itemPrice; //物品价格
    [Range(0, 1)] public float sellPercentage; //0-1物品打折百分比
}

[System.Serializable]
public struct InventoryItem
{
    public int itemID;
    public int itemAmount;
}