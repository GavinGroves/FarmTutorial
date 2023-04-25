using Cinemachine;//调用命名空间
using UnityEngine;

/// <summary>
/// 设置摄像机边界
/// </summary>
public class SwitchBounds : MonoBehaviour
{
    private PolygonCollider2D m_confinerShape;
    private CinemachineConfiner m_confiner;
    
    //Todo:切换场景后更改调用
    void Start()
    {
        SwitchConfinerShape();
    }

    /// <summary>
    /// 切换场景后，亦能自动更改摄像机BoundingShape2D
    /// </summary>
    private void SwitchConfinerShape()
    {
        //查找有Tag标签为Bound边界的物体，获取它的边界碰撞体组件；通过标签查找对应物体
        m_confinerShape = GameObject.FindGameObjectWithTag("BoundsConfiner").GetComponent<PolygonCollider2D>();
        //获取相机
        m_confiner = GetComponent<CinemachineConfiner>();
        //相机的边界值赋值为查找到的 边界
        m_confiner.m_BoundingShape2D = m_confinerShape;
        //切换边界的时候没有成功，需要清理缓存
        //Call this if the bounding shape's points change at runtime
        m_confiner.InvalidatePathCache();
    }
}
