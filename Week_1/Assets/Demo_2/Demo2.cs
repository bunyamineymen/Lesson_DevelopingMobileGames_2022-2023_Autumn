using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Demo2 : MonoBehaviour
{

    public UnityEvent UE_Event;

    public void Run_UnityEvent()
    {
        Debug.Log("ButtonClick_UnityEvent");
    }

    public void ButtonClick_MyButton()
    {
        UE_Event?.Invoke();
    }

}
