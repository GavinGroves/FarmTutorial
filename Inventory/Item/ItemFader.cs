using UnityEngine;
using DG.Tweening;
/// <summary>
/// 实现 Trigger 触发半透明和还原
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]//确保一定有这个组件
public class ItemFader : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 逐渐恢复颜色
    /// </summary>
    public void FadeIn()
    {
        //a表示透明度，1为完全显示
        Color targetColor = new Color(1, 1, 1, 1);
        //DOColor（目标颜色，渐变时间）
        m_SpriteRenderer.DOColor(targetColor, Settings.fadeDuration);
    }
    
    /// <summary>
    /// 逐渐半透明
    /// </summary>
    public void FadeOut()
    {
        //a透明度为0.45f,一半
        Color targetColor = new Color(1, 1, 1, Settings.targetAlpha);
        //DOColor（目标颜色，渐变时间）
        m_SpriteRenderer.DOColor(targetColor, Settings.fadeDuration);
    }
}
