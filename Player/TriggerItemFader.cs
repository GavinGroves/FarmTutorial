using System;
using UnityEngine;

/// <summary>
/// 人物碰撞到某物体法的触发器，执行相应功能
/// </summary>
public class TriggerItemFader : MonoBehaviour
{
    private ItemFader[] faders;

    /// <summary>
    /// 进入触发器，执行功能
    /// </summary>
    /// <param name="col">接收到人物碰撞到的碰撞体col</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        //获取父树下两个子物体的脚本（拥有渐变功能）组件
        faders = col.GetComponentsInChildren<ItemFader>();
        //安全判断：如果获取到
        if (faders.Length > 0)
        {
            //遍历执行，也就是两个子物体都执行该脚本组件的渐变方法
            foreach (var item in faders)
            {
                item.FadeOut();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        faders = other.GetComponentsInChildren<ItemFader>();
        if (faders.Length > 0)
        {
            foreach (var item in faders)
            {
                item.FadeIn();
            }
        }
    }
}