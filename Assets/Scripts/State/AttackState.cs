using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    #region

    #endregion
    public void Handle()
    {
        //处理状态的切换
        //如果血量小于等于0，要切换到死亡状态
        //如果血量小于等于10，要切换到逃跑状态
        //如果玩家死亡/或从敌人眼前丢失，切换回巡逻状态

    }

    public void Update()
    {
        Attack();
    }

    public void Attack()
    {
        //攻击玩家
    }
}
