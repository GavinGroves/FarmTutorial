using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace MFarm.Inventory
{
    public class SlotUI : MonoBehaviour, IPointerClickHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        [Header("组件获取")] [SerializeField] private Image slotImage;
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] public Image slotHighlight;
        [SerializeField] private Button button;

        public SlotType slotType; //定义背包的类型
        public bool isSelected; //是否被点击 → 点击就会高亮格子
        public int slotIndex;

        //物品信息
        public ItemDetails itemDetails;
        public int itemAmount;
        
        //获取父物体脚本组件
        private InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

        private void Start()
        {
            isSelected = false;
            //格子没有物体
            if (itemDetails.itemID == 0)
            {
                UpdateEmptySlot();
            }
        }

        /// <summary>
        /// 更新格子的UI信息
        /// </summary>
        /// <param name="item">ItemDetails</param>
        /// <param name="amount">持有数量</param>
        public void UpdateSlot(ItemDetails item, int amount)
        {
            itemDetails = item;
            slotImage.sprite = item.itemIcon;
            slotImage.enabled = true;
            itemAmount = amount;
            amountText.text = amount.ToString();
            button.interactable = true;
        }

        /// <summary>
        /// 将slot更新为空的（最初始，什么都没有的情况）
        /// </summary>
        public void UpdateEmptySlot()
        {
            //空格子被点击，不能高亮，isSelected设置成FALSE
            if (isSelected)
            {
                isSelected = false;
            }

            slotImage.enabled = false; //图片关闭
            amountText.text = string.Empty; //文本清空
            button.interactable = false; //按钮不能点按
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (itemAmount == 0) return;
            isSelected = !isSelected;
            
            inventoryUI.UpdateSlotHighlight(slotIndex);
        }

        //拖拽事件
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (itemAmount != 0)
            {
                inventoryUI.dragItem.enabled = true;
                inventoryUI.dragItem.sprite = slotImage.sprite;
                inventoryUI.dragItem.SetNativeSize();
                
                isSelected = true;
                inventoryUI.UpdateSlotHighlight(slotIndex);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            inventoryUI.dragItem.transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            inventoryUI.dragItem.enabled = false;
            Debug.Log(eventData.pointerCurrentRaycast.gameObject);
        }
    }
}