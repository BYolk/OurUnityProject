using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class CharacterMove : MonoBehaviour
{
    #region

    #endregion
    float speed = 3.0f;
    CharacterController controller;
    Animator animator;
    float pushPower = 10.0f;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.center = new Vector3(0, 0.75f, 0);
        controller.height = 1.6f;
        controller.radius = 0.4f;
        controller.slopeLimit = 90.0f;
        controller.skinWidth = 0.05f;
        controller.minMoveDistance = 0f;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = Vector3.zero;

        if (Input.GetButton("Jump"))
        {
            //controller.SimpleMove(Vector3.up * speed);
            controller.Move(Vector3.up * speed * Time.deltaTime);
        }

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Move", true);
            dir = new Vector3(horizontal, 0, vertical);
            //controller.Move(dir * speed * Time.deltaTime);
            Vector3 worldDir = transform.TransformDirection(dir);
            controller.SimpleMove(worldDir * speed);//如果角色在空中，SimpleMove 方法只会在 Y 轴上移动角色，原因是调用 SimpleMove 方法，会自带重力，在空中，SimpleMove无法控制角色 X 坐标和 Z 坐标的一个改变
            //如果斜坡接近 90° 且高度比角色控制器 Step Offset 指定的值还要高很多，无论 Slope Limit 为多少，都无法攀爬
            //如果斜坡接近 90° 且高度只比角色控制器 Step Offset 指定的值略高，只要 Slop Limit 为 90°，还是可以爬上去的
            //如果斜坡接近 90° 且高度只比角色控制器 Step Offset 指定的值略高，但是 Slop Limit 小于斜坡坡度，是无法攀爬上去的，想要攀爬上去，必须将 Step Offset 的值调整到大于等于斜坡（墙）的高度，同时小于等于角色控制器的高度
        }
        else
        {
            animator.SetBool("Move", false);
        }
        
    }



    /// <summary>
    /// 当角色控制器与场景中的物体发生碰撞时，会自动调用这个方法
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Rigidbody body = hit.collider.attachedRigidbody;
        Rigidbody body = hit.rigidbody;
        if (body == null || body.isKinematic)
        {
            return;
        }

        // 定义推力的方向，只要 X 坐标和 Z 坐标的方向
        Vector3 pushDir = hit.moveDirection;
        // 给被碰撞物体应用推力
        //body.velocity = pushDir * pushPower;
        body.AddForce(pushDir * pushPower);
    }
}
