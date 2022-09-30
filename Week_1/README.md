
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 1

Developing Mobile Game lesson for Ankara university - Week 1

## Unity Installation

For downloading Unity Game Engine ,at first download [Unity-Hub](https://unity3d.com/get-unity/download) tool.


<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Installation/phase_1.PNG" width=629.5 height=477 >
    </td>
  </tr>
 </table>

   <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Installation/phase_2.PNG" width=760.5 height=425 >
    </td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Installation/phase_3.PNG" width=771.5 height=426 >
    </td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Installation/phase_4.PNG" width=773 height=427.5 >
    </td>
  </tr>

  
  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Installation/phase_5.PNG" width=773 height=427.5 >
    </td>
  </tr>

 </table>

## Development Preparation


### Set IDE for development in unity.

Set Visual Studio for Unity environment
Edit - Preference - External Script Editor

<table>
  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Preparation/IDE.png"></td>
  </tr>
 </table>



### The Hierarchy window

The Hierarchy window displays every GameObject in a Scene, such as models, Cameras, or Prefabs. You can use the Hierarchy window to sort and group the GameObjects you use in a Scene. When you add or remove GameObjects in the Scene view, you also add or remove them from the Hierarchy window.

The Hierarchy window can also contain other Scenes, with each Scene
 containing their own GameObjects.

<table>
  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Preparation/The%20Hierarchy%20window.png"></td>
  </tr>
 </table>



 ### The Project window

The Project window displays all of the files related to your Project and is the main way you can navigate and find Assets and other Project files in your application. When you start a new Project by default this window is open. However, if you cannot find it, or it is closed, you can open it via Window > General > Project or press Ctrl+5 (macOS: Cmd+5).

<table>
  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Preparation/ProjectWindow.png"></td>
  </tr>
 </table>



 ### The Scene view

The Scene view is your interactive view into the world you are creating. You can use the Scene view to select and position scenery, characters, Cameras, lights, and all other types of GameObjects.Selecting manipulating, and modifying GameObjects in the Scene view are some of the first skills you must learn to begin working in Unity.

<table>
  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_1/Assets/_Resources/Preparation/SceneView.png"></td>
  </tr>
 </table>



## Demo 1 

* Create Canvas and basic canvas components
* Canvas Scaler - UI Scale Mode
* Text & TextMeshPRO
* Basic RectTransform
* Image component and use as background
* Button component and basic use

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo1.png"></td>

  </tr>
 </table>

   ```csharp

public class Demo1 : MonoBehaviour
{
    #region MyButton

    public Button Btn_MyButton;

    private void Awake()
    {
        Btn_MyButton.onClick.AddListener(ButtonClick_MyButton);
    }

    public void ButtonClick_MyButton()
    {
        Debug.Log("ButtonClick_MyButton");
    }

    #endregion
}

  ```

## Demo 2

* Unityevent
* EventSystem
* Graphic Raycaster
* Canvas - Render Mode

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo2.png"></td>

  </tr>
 </table>

   ```csharp

public class Demo2 : MonoBehaviour
{

    public UnityEvent UE_Event;

    public void Run_UnityEvent()
    {
        Debug.Log("ButtonClick_UnityEvent");
    }

    public void ButtonClick_MyButton()
    {
        UE_Event?.Invoke();
    }

}

  ```
  
## Demo 3

* GameObject.Find unity command
* Console window
* Inspector window
* Project window
* Shortcut: CTRL D , CTRL E
* Time Offset : Ienumarator , System.Threading.Tasks

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo3.png"></td>

  </tr>
 </table>

   ```csharp

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

  ```
  
## Demo 4

* Monobehaviour Methods and Lifecycle

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo4.png"></td>

  </tr>
 </table>

   ```csharp

public class Demo4 : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void Start()
    {
        Debug.Log("Start");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    private void Update()
    {
        Debug.Log("Update");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }
}

  ```
  
## Demo 5

* Script Execution Order

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo5.png"></td>

  </tr>
 </table>

```csharp

public class Demo5Script1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start 1");
    }
}

public class Demo5Script2 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start 2");
    }
}

```
  


  ## Demo 6

* Access other monobehaviour script.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo6.png"></td>

  </tr>
 </table>

   ```csharp

public class Demo6Script1 : MonoBehaviour
{

    public Demo6Script2 demo6Script2;

    private void Start()
    {
        demo6Script2.MainLogic();
    }

}

public class Demo6Script2 : MonoBehaviour
{
    public void MainLogic()
    {
        Debug.Log("MainLogic");
    }
}


  ```
  


  ## Demo 7

* Singleton pattern

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson1_DevelopingMobileGame/main/Assets/_Resources/demo7.png"></td>

  </tr>
 </table>

```csharp

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

public class Demo7Script2 : MonoBehaviour
{
    private void Start()
    {
        Demo7.instance.MainMethod();
    }
}

  ```

