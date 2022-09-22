using System.Collections;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

public class Demo3 : MonoBehaviour
{

    private Button Btn_MyButton;

    public async void ButtonClick_MyButton()
    {
        Debug.Log("ButtonClick_MyButton phase_1");
        await Task.Delay(1000);
        StartCoroutine(ButtonClick_MyButton_IEnumerator());
    }

    private void Awake()
    {
        Btn_MyButton = GameObject.Find("MyButton").GetComponent<Button>();

        Btn_MyButton.onClick.AddListener(ButtonClick_MyButton);
    }

    IEnumerator ButtonClick_MyButton_IEnumerator()
    {
        Debug.Log("ButtonClick_MyButton phase_2");

        yield return new WaitForSeconds(1f);

        Debug.Log("ButtonClick_MyButton phase_3");
    }

}
