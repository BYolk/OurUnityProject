using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    #region

    #endregion
    

    enum State
    {
        PATROL,
        ATTACK,
        DEATH,
        RUNAWAY
    }
    State currentState = State.PATROL;


    private void Update()
    {
        switch (currentState)
        {
            case State.PATROL:
                float hp = transform.GetComponent<Monster>().HP;
                if (hp <= 0)
                {
                    currentState = State.DEATH;
                    break;
                }
                if(hp <= 10)
                {
                    currentState = State.RUNAWAY;
                    break;
                }

                bool isDetectPlayer = Patrol();
                if (isDetectPlayer)
                {
                    currentState = State.ATTACK;
                }
                break;
            case State.ATTACK:
                hp = transform.GetComponent<Monster>().HP;
                if (hp <= 0)
                {
                    currentState = State.DEATH;
                    break;
                }
                if (hp <= 10)
                {
                    currentState = State.RUNAWAY;
                    break;
                }

                Attack();
                break;
            case State.DEATH:
                Death();
                break;
            case State.RUNAWAY:
                if (transform.GetComponent<Monster>().HP <= 0)
                {
                    currentState = State.DEATH;
                    break;
                }
                RunAway();
                break;
            default:
                break;

        }
    }


    public bool Patrol()
    {
        return false;//���ز���ֵ����ʾ�Ƿ��⵽��ң������⵽��ң�Ӧ���л�������״̬
    }


    public void Attack()
    {
        //�������
    }

    public void Death()
    {
        //Destroy(this);
    }
    public void RunAway()
    {
        //Run Away
    }
}
