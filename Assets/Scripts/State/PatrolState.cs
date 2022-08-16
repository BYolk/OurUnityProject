using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    #region

    #endregion
    bool isDetectedPalyer;
    public void Handle()
    {
        //如果血量小于等于0，要切换到死亡状态
        //如果血量小于等于10，要切换到逃跑状态
        //进行状态的切换处理
        if (isDetectedPalyer)
        {
            //说明识别到玩家，切换到攻击状态
            //切换类对象，将当前的巡逻状态对象切换成攻击状态对象
        }
    }

    public void Update()
    {
        //进行状态行为方法的调用
        isDetectedPalyer = Patrol();
    }
    
    public bool Patrol()
    {
        return false;
    }
}
