using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerCubeManager : MonoBehaviour
{
    private Vector3 FirstCubePosition = Vector3.zero;
    private float stepLength = 0.043f;

    public List<CubeBehaviour> listOfCubeBehaviour = new List<CubeBehaviour>();

    private bool dropMode = false;


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

        int indexOfCube = listOfCubeBehaviour.Count - 1;

        ReorderCubes();



        var playerTransform = PlayerBehaviour.Instance.transform;
        Vector3 playerTarget = new Vector3(0f, (indexOfCube) * stepLength + 0.0226f, 0f);
        playerTransform.DOLocalMove(playerTarget, 0.05f);



    }

    public void DropCube(CubeBehaviour cubeBehaviour)
    {
        cubeBehaviour.transform.parent = null;

        listOfCubeBehaviour.Remove(cubeBehaviour);

        //ReorderCubes();



        //player
        int indexOfCube = listOfCubeBehaviour.Count - 1;

        var playerTransform = PlayerBehaviour.Instance.transform;
        Vector3 playerTarget = new Vector3(0f, (indexOfCube) * stepLength + 0.0226f, 0f);
        playerTransform.DOLocalMove(playerTarget, 0.05f);

    }



    private void ReorderCubes()
    {
        //reorder cubes
        int index = listOfCubeBehaviour.Count - 1;
        foreach (var cube in listOfCubeBehaviour)
        {
            Vector3 target = new Vector3(0f, index * stepLength, 0f);
            cube.transform.DOLocalMove(target, 0.15f);
            index--;
        }
    }
}
