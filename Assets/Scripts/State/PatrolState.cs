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
        //���Ѫ��С�ڵ���0��Ҫ�л�������״̬
        //���Ѫ��С�ڵ���10��Ҫ�л�������״̬
        //����״̬���л�����
        if (isDetectedPalyer)
        {
            //˵��ʶ����ң��л�������״̬
            //�л�����󣬽���ǰ��Ѳ��״̬�����л��ɹ���״̬����
        }
    }

    public void Update()
    {
        //����״̬��Ϊ�����ĵ���
        isDetectedPalyer = Patrol();
    }
    
    public bool Patrol()
    {
        return false;
    }
}
