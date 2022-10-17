
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 2

Developing Mobile Game lesson for Ankara university - Week 2

At the beginning of the lesson , "Package Manager" will be mentioned.
Then we will import Dotween and CartoonFX unitypackages from asset store.

## Demo 1 

* Scene Works
* Motion
* FixedUpdate

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo1.png"></td>

  </tr>
 </table>

 ```csharp

using UnityEngine;

public class Player : MonoBehaviour
{
    private const float velocity = 700f;

    private void FixedUpdate()
    {
        transform.position += new Vector3(0f, 0, 0.001f) * velocity;
    }
}

  ```


[👉 Learn more about FixedUpdate](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html)



  ## Demo 2

* PlayerPrefs
* PlayerPrefs editor

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo2.png"></td>

  </tr>
 </table>

   ```csharp

public class Demo2 : MonoBehaviour
{

    private TextMeshProUGUI txt_Variable;

    private void Awake()
    {
        txt_Variable = GameObject.Find("Txt_Variable").GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("Variable"))
        {
            txt_Variable.text = PlayerPrefs.GetString("Variable");
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Variable"))
        {
            PlayerPrefs.SetString("Variable", "This is variable !!!");
            PlayerPrefs.SetInt("Score", 9);
            PlayerPrefs.SetFloat("percentage", 0.67f);
        }
    }

}

  ```

[👉 Learn more about PlayerPrefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html)

## Demo 3

* DontDestroyOnLoad

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo3.png"></td>

  <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo3_2.png">
    </td>

  </tr>
 </table>

 ```csharp

public class Demo3_First : MonoBehaviour
{

    private Button btn_GoToScene2;

    private void Awake()
    {
        btn_GoToScene2 = GameObject.Find("Btn_GoToScene2").GetComponent<Button>();

        btn_GoToScene2.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Demo3_Second");
        });

    }
}

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

  ```

[👉 Learn more about DontDestroyOnLoad](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html)

  ## Demo 4

* Animator
* Animation Clip - Loop Time
* Animation Event
* Animation Speed

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo4.png"></td>

  </tr>
 </table>

 ```csharp

public class Demo4 : MonoBehaviour
{
    public void Trigger_AnimationEvent()
    {
        Debug.Log("I am at the ground...");
    }
}

  ```

[👉 Learn more about Animator](https://learn.unity.com/tutorial/controlling-animation)



  ## Demo 5

* Run Particle Effect
* Instantiate command
* Rigidbody.AddForce command

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo12.png"></td>

  </tr>
 </table>

```csharp

public class Demo12 : MonoBehaviour
{

    public GunBehaviour GunBehaviour;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunBehaviour.Shoot();
        }
    }
}

```

```csharp

public class GunBehaviour : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletReference;

    public const float velocity = 5000;

    public void Shoot()
    {
        var bullet = Instantiate(Bullet, BulletReference.position, Quaternion.identity);
        var rgb = bullet.GetComponent<Rigidbody>();
        rgb.AddForce(BulletReference.forward * velocity, ForceMode.Force);
    }
}

```

## Resources

- [:book: Scriptable Object](https://www.youtube.com/watch?v=BFYRUDk6TDs)
- [:book: Particle System](https://www.youtube.com/watch?v=FEA1wTMJAR0)
- [:book: Movement](https://www.youtube.com/watch?v=ixM2W2tPn6c)

## Next Lesson Topics

- Rigidbody
- Colliders
- Gravity
- Physic materials, bounce, colliding
- Raycasting
- Collision matrix 

