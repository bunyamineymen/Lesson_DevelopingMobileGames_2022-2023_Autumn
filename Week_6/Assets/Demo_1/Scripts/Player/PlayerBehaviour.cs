using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static System.TimeZoneInfo;
using static UnityEngine.GraphicsBuffer;

public class PlayerBehaviour : MonoBehaviour
{

    public Animator animatorOfPlayer;

    public PlayerMoverRunner playerMoverRunner;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static PlayerBehaviour Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    #endregion

    public void VictoryAnimation()
    {
        animatorOfPlayer.SetTrigger("Victory");
    }

    public void FailAnimation()
    {
        animatorOfPlayer.SetTrigger("Fail");

        DOTween.To(() => playerMoverRunner.Velocity, x => playerMoverRunner.Velocity = x, 0, 0.003f);

    }

}
