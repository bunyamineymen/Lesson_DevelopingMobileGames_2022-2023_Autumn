using DG.Tweening;

using UnityEngine;

public class PlayerCubeManager : MonoBehaviour
{
    private Vector3 FirstCubePosition = Vector3.zero;
    private float stepLength = 0.043f;
    private int cubeCount = 1;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static PlayerCubeManager Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    #endregion



    public void GetCube(CubeBehaviour cubeBehaviour)
    {
        cubeBehaviour.transform.parent = transform;

        int indexOfCube = cubeCount;
        Vector3 target = new Vector3(0f, indexOfCube * stepLength, 0f);
        cubeBehaviour.transform.DOLocalMove(target, 0.15f);

        var playerTransform = PlayerBehaviour.Instance.transform;
        Vector3 playerTarget = new Vector3(0f, (indexOfCube) * stepLength + 0.0226f, 0f);
        playerTransform.DOLocalMove(playerTarget, 0.05f);

        cubeCount++;
    }





}
