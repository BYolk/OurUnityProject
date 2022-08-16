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
            controller.SimpleMove(worldDir * speed);//�����ɫ�ڿ��У�SimpleMove ����ֻ���� Y �����ƶ���ɫ��ԭ���ǵ��� SimpleMove ���������Դ��������ڿ��У�SimpleMove�޷����ƽ�ɫ X ����� Z �����һ���ı�
            //���б�½ӽ� 90�� �Ҹ߶ȱȽ�ɫ������ Step Offset ָ����ֵ��Ҫ�ߺܶ࣬���� Slope Limit Ϊ���٣����޷�����
            //���б�½ӽ� 90�� �Ҹ߶�ֻ�Ƚ�ɫ������ Step Offset ָ����ֵ�Ըߣ�ֻҪ Slop Limit Ϊ 90�㣬���ǿ�������ȥ��
            //���б�½ӽ� 90�� �Ҹ߶�ֻ�Ƚ�ɫ������ Step Offset ָ����ֵ�Ըߣ����� Slop Limit С��б���¶ȣ����޷�������ȥ�ģ���Ҫ������ȥ�����뽫 Step Offset ��ֵ���������ڵ���б�£�ǽ���ĸ߶ȣ�ͬʱС�ڵ��ڽ�ɫ�������ĸ߶�
        }
        else
        {
            animator.SetBool("Move", false);
        }
        
    }



    /// <summary>
    /// ����ɫ�������볡���е����巢����ײʱ�����Զ������������
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

        // ���������ķ���ֻҪ X ����� Z ����ķ���
        Vector3 pushDir = hit.moveDirection;
        // ������ײ����Ӧ������
        //body.velocity = pushDir * pushPower;
        body.AddForce(pushDir * pushPower);
    }
}
