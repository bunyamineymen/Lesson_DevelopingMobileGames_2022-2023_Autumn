
using System.Collections;

using UnityEngine;

public class Demo3Manager : MonoBehaviour
{

    #region Singleton

    public static Demo3Manager Instance { get; private set; }

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    private void Awake()
    {
        Debug.Log("Awake");

        Singleton();
    }

    private void Start()
    {
        StartCoroutine(DebugLogIEnumerator());
    }

    IEnumerator DebugLogIEnumerator()
    {
        var yieldReturn = new WaitForSeconds(0.3f);

        while (true)
        {
            yield return yieldReturn;
            Debug.Log("Demo3Manager");
        }
    }

}
