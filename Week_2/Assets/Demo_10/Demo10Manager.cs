using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Demo10Manager : MonoBehaviour
{
    public Demo10 demo10;

    private void Start()
    {
        StartCoroutine(DebugLogIEnumerator());
    }

    IEnumerator DebugLogIEnumerator()
    {
        var yieldReturn = new WaitForSeconds(demo10.period);

        while (true)
        {
            yield return yieldReturn;

            Debug.Log("Log");
        }

    }
}
