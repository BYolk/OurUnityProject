using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    #region

    #endregion
    public void Handle()
    {
        //处理状态的切换
        //如果玩家死亡/或从敌人眼前丢失，切换回巡逻装填
        //如果敌人死亡，敌人要切换到死亡状态
    }

    public void Update()
    {
        Death();
    }

    public void Death()
    {
        //销毁自身
    }
}
