/// <summary>
/// 枚举物品类型
/// </summary>
public enum ItemType
{
    Seed, // 种子
    Commodity, //商品
    Furniture, //家具

    HoeTool, //锄头工具，锄地
    ChopTool, //砍树工具
    BreakTool, //凿石头工具
    ReapTool, //割草工具
    WaterTool, //浇水工具
    CollectTool, //收集物品的篮子工具

    ReapableScenery //可以收割的杂草
}

/// <summary>
/// 背包类型
/// </summary>
public enum SlotType
{
    Bag,Box,Shop
}

/// <summary>
/// 确认库存在哪个位置
/// </summary>
public enum InventoryLocation
{
    Player,Box
}

