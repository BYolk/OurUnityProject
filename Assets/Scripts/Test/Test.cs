using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    #region

    #endregion


    private void Update()
    {
        Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate------------------");

    }
    public void TestGeneric<T>() where T : MonoBehaviour
    {
        
    }
}
