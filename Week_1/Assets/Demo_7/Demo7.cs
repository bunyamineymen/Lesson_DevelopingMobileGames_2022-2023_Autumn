
using System.Security.Cryptography;

using UnityEngine;

public class Demo7 : MonoBehaviour
{
    #region Singleton

    public static Demo7 instance;

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        Singleton();
    }

    public void MainMethod()
    {
        Debug.Log("MainMethod");
    }

}
