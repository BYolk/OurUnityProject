using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    #region

    #endregion
    void Handle();//处理状态的切换条件
    void Update();//每帧调用状态的行为方法
}
