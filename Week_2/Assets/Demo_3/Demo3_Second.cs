
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Demo3_Second : MonoBehaviour
{

    private Button btn_GoToScene1;

    private void Awake()
    {
        btn_GoToScene1 = GameObject.Find("Btn_GoToScene1").GetComponent<Button>();

        btn_GoToScene1.onClick.AddListener(GoToScene1);

    }

    private void GoToScene1()
    {
        SceneManager.LoadScene("Demo3_First");
    }
}
