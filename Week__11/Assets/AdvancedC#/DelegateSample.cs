using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DelegateSample : MonoBehaviour
{

    // Delegate tanımlaması
    public delegate void SayiDelegate(int sayi);

    // Delegate objesi oluşturmak
    public SayiDelegate delegateObject;

    private void OnEnable()
    {
        delegateObject = NumberTest1; // No Problem
        delegateObject = NumberTest2; // No Problem
        //delegateObjesi = NumberTest3; 
        //delegateObjesi = NumberTest4; 
        //delegateObjesi = NumberTest5; 
    }

    private void OnDisable()
    {
        delegateObject = null;
    }

    private async void Start()
    {
        await System.Threading.Tasks.Task.Delay(3000);

        delegateObject.Invoke(4);
        delegateObject(5);

    }

    private void NumberTest1(int deger) // Name of parameter does not have to be same with parameter name of delegate
    {
        Debug.Log(deger);

    }

    public static void NumberTest2(int i) // Function can be static
    {
        i = i * 2;
        Debug.Log(i);
    }

    public bool NumberTest3(int sayi)
    {
        return sayi == 0;
    }

    public void NumberTest4(float f)
    {
        Debug.Log(f);
    }

    public void NumberTest5(int sayi, bool debugLog)
    {
        if (debugLog)
            Debug.Log(sayi);
    }

}
