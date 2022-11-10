using DG.Tweening;

using System.Collections.Generic;

using UnityEngine;

public class PlayerCubeManager : MonoBehaviour
{
    private float stepLength = 0.043f;
    private float groundYValue = -0.0213f;

    public List<CubeBehaviour> listOfCubeBehaviour = new List<CubeBehaviour>();

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
        listOfCubeBehaviour.Add(cubeBehaviour);
        cubeBehaviour.isStacked = true;

        cubeBehaviour.transform.parent = transform;

        ReorderCubes();

        RelocatePlayer();

    }

    private void RelocatePlayer()
    {
        var playerTransform = PlayerBehaviour.Instance.transform;
        Vector3 playerTarget = new Vector3(0f, (listOfCubeBehaviour.Count) * stepLength + groundYValue, 0f);
        playerTransform.DOLocalMove(playerTarget, 0.05f);
    }

    public void DropCube(CubeBehaviour cubeBehaviour)
    {
        cubeBehaviour.transform.parent = null;
        cubeBehaviour.isStacked = false;

        listOfCubeBehaviour.Remove(cubeBehaviour);

        if (listOfCubeBehaviour.Count < 1)
        {
            Debug.Log("Gameover");

            PlayerBehaviour.Instance.FailAnimation();
            PlayerBehaviour.Instance.StopPlayer();

            var playerTransform2 = PlayerBehaviour.Instance.transform;
            Vector3 groundTarget = new Vector3(0f, -0.016f, -0.14f);
            playerTransform2.DOLocalJump(groundTarget, 0.05f, 1, 0.5f);

            return;
        }

        RelocatePlayer();

    }

    private void ReorderCubes()
    {
        int index = listOfCubeBehaviour.Count - 1;
        foreach (var cube in listOfCubeBehaviour)
        {
            Vector3 target = new Vector3(0f, index * stepLength, 0f);
            cube.transform.DOLocalMove(target, 0.05f);
            index--;
        }
    }
}
