
using System.Collections;

using UnityEngine;

public class Demo4 : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DisplayCommandIEnumerator());
    }

    IEnumerator DisplayCommandIEnumerator()
    {
        var yieldReturn = new WaitForSeconds(1f);

        while (true)
        {
            yield return yieldReturn;

            Debug.Log($" Time.time {Time.time}");
            Debug.Log($" Time.realtimeSinceStartup {Time.realtimeSinceStartup}");
            Debug.Log($" Time.captureDeltaTime {Time.captureDeltaTime}");
            Debug.Log($" Time.fixedDeltaTime {Time.fixedDeltaTime}");
            Debug.Log($" Time.frameCount {Time.frameCount}");
            Debug.Log($" Time.deltaTime {Time.deltaTime}");
            Debug.Log($" Time.unscaledDeltaTime {Time.unscaledDeltaTime}");
            Debug.Log($" Time.captureFramerate {Time.captureFramerate}");
            Debug.Log($" Time.fixedTime {Time.fixedTime}");
            Debug.Log($" Time.unscaledTime {Time.unscaledTime}");
            Debug.Log($" Time.timeSinceLevelLoad {Time.timeSinceLevelLoad}");
            Debug.Log($" Time.timeAsDouble {Time.timeAsDouble}");
            Debug.Log($" Time.fixedUnscaledTimeAsDouble {Time.fixedUnscaledTimeAsDouble}");

        }
    }
}
