using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public SwerveMovement SwerveMovement;
    public SwerveInputSystem SwerveInputSystem;
    public PlayerMoverRunner PlayerMoverRunner;

    public RectTransform WinUI;
    public RectTransform FailUI;

    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    #endregion

    public void ActivateWinUI()
    {
        WinUI.gameObject.SetActive(true);
        Vector3 defaultScale = WinUI.transform.localScale;

        WinUI.transform.localScale = Vector3.one * 0.0001f;
        WinUI.DOScale(defaultScale, 1f).SetEase(Ease.OutBounce);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
