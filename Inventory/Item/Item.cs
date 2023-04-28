using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class Item : MonoBehaviour
    {
        public int itemID;
        private SpriteRenderer m_SpriteRenderer;
        private BoxCollider2D m_BoxCollider2D;
        public ItemDetails m_ItemDetails;

        private void Awake()
        {
            m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            m_BoxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            if (itemID != 0)
            {
                Init(itemID);
            }
        }

        /// <summary>
        /// 初始化显示的物品
        /// </summary>
        public void Init(int ID)
        {
            itemID = ID;

            //Inventory获得当前数据
            m_ItemDetails = InventoryManager.Instance.GetItemDetails(itemID);

            //安全判断，不为空执行
            if (m_ItemDetails != null)
            {
                //图片放置地图：如果Hold图标不为空就用，否则用Icon
                m_SpriteRenderer.sprite = m_ItemDetails.itemOnWorldSprite != null
                    ? m_ItemDetails.itemOnWorldSprite
                    : m_ItemDetails.itemIcon;

                //修改碰撞体尺寸
                Vector2 newSize = new Vector2(m_SpriteRenderer.sprite.bounds.size.x,
                    m_SpriteRenderer.sprite.bounds.size.y);
                m_BoxCollider2D.size = newSize;
                //碰撞体盒子Y轴改为Center Y （向上移）
                m_BoxCollider2D.offset = new Vector2(0, m_SpriteRenderer.sprite.bounds.center.y);
            }
        }
    }
}