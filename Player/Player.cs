using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物控制
/// </summary>
public class Player : MonoBehaviour
{
    private Transform m_Transform;
    private Rigidbody2D m_Rigidbody2d;

    public float speed;
    private float inputX;
    private float inputY;
    private Vector2 movementInput;

    void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// 获取人物按键移动的输入方向
    /// </summary>
    private void PlayerInput()
    {
        //如果要设置人物不能斜着走，添加if判断,只有Y轴按键没按，才能执行X轴按键
        //if(inputY==0) 
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        //斜方向着走，速度变慢 ; 设置同时按下两个按键的情况减速
        if (inputX != 0 && inputY != 0)
        {
            inputX *= 0.6f;
            inputY *= 0.6f;
        }

        movementInput = new Vector2(inputX, inputY);
    }

    /// <summary>
    /// 人物移动,使用刚体
    /// </summary>
    private void Movement()
    {
        m_Rigidbody2d.MovePosition(m_Rigidbody2d.position + movementInput * (speed * Time.deltaTime));
    }
}