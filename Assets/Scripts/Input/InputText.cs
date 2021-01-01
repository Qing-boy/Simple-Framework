using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //开启输入检测
        InputMgr.GetInstance().StartOrEndCheck(true);

        //添加事件监听
        EventCenter.GetInstance().AddEventListener("某键按下", CheckInputDown);
        EventCenter.GetInstance().AddEventListener("某键抬起", CheckInputUp);
    }

   private void CheckInputDown(object key)
   {
        KeyCode code = (KeyCode)key;
        switch(code)
        {
            case KeyCode.W:
                Debug.Log("W下");
                break;
            case KeyCode.A:
                Debug.Log("A下");
                break;
            case KeyCode.S:
                Debug.Log("S下");
                break;
            case KeyCode.D:
                Debug.Log("D下");
                break;
        }
   }

    private void CheckInputUp(object key)
    {
        KeyCode code = (KeyCode)key;
        switch (code)
        {
            case KeyCode.W:
                Debug.Log("W上");
                break;
            case KeyCode.A:
                Debug.Log("A上");
                break;
            case KeyCode.S:
                Debug.Log("S上");
                break;
            case KeyCode.D:
                Debug.Log("D上");
                break;
        }
    }
}
