
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 4

Developing Mobile Game lesson for Ankara university - Week 4



# Demo 1 
## Rigidbody Example

Rigidbody is a component which allows GameObjects to connect with physics engine.
With rigidbody; you can make a gameobject collidable, gravity dependent and force effectible.

For applying rigidbody component to our GameObject, we have two basic way.

## 1) Adding Rigidbody Component on Editor.

We can directly add a gameobject by using our Unity editor.
You have to select your gameobject on "Hierarch" list first.
And after that, you can see your GameObject's attributes and components at right bar.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_4/Assets/_Resources/demo1_1.png"></td>

  </tr>
 </table>

 Now you can click "Add component" button. And component searchbox will be shown.
 You can type "Rigidbody" here. And select the component 
 **Attention: if you are working on a 2D project, you have to add Rigidbody2D. Otherwise, you should add just "Rigidbody"

## 2) Adding with programming at runtime

```csharp
GameObject ourGameObject; //May assigned from editor or assigned on runtime by find, findByTag or etc.
 if (!gameobject.GetComponent<Rigidbody>())
{
    Rigidbody newRigidbody = gameobject.AddComponent<Rigidbody>();
    newRigidbody.mass = mass;
}
```











# Demo 3 
## Gravity Example

You have several ways nake your gameobjects gravity-independent.

## 1) Manipulating "Use Gravity" attribute
Or best option is setting "Use Gravity" option disabled.
By doing this, you can make your gameobject gravit affected or not affected at any time in your game.
Note: When you set a gravity to object and removed it later, you can observe that object still moves to ground but slower. This happens because when you
unticked the use gravity, your object has became gravity acceleration independent. 
But it still remains its velocity. So, you can set its velocity to zero or make its isKinematic attribute ticked.

## 2) Manipulating Is Kinematic Switching
If your gameobject should affected by physics generally but you just want to make it unaffected for a while,
you can disable isKinematic attribute by code (at runtime) or by editor from inspector panel.


## 3) Removing Rigidbody
Other option is dealing with physical-nonphysical switching.
So you can basically remove rigidbody component (Or you kindly don't add at creation of object).
We don't recommend it if you need to use this object with physics later.

## 4) Wrong Way : Trying to manipulating with mass.

Also, you may think about making mass value of gameobject's rigidbody component 0.
Like as real life, a object without mass can not affected by gravity should swing on the sky.
But, actually we don't expect that both of unity and real life. Because in real life, you can not create any object that has zero mass.
Because all particles of atom and even a electron has a mass.
So, we can not do this unity either. Unity don't allow developers to create gameobject with zero gravity.
Its because colliding with object that has zero gravity may cause unstable conditions.
For example, we can not calculate momentum of a collision of zero mass object.
When you mass value to 0 from editor, you can see that unity replaces zero with "1e-07" value.
This represents "0.0000001" value. So, this is ourminimum mass value for each gameobject.
Also remember, when you set an objects mass to zero, game engine will replace it with "1e-07" value automatically.

















  ## Demo 1

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

  ## Demo 2

* PingPong Motion

 ```csharp

public class Demo2Run : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rgb;

    private void Start()
    {
    }

    private void Update()
    {
        Slide(tr, Vector3.right);
    }

    void Slide(Transform target, Vector3 railDirection)
    {
        Vector3 heading = target.position - transform.position;
        Vector3 force = Vector3.Project(heading, railDirection);

        rgb.AddForce(force);
    }

}

  ```

  ## Demo 3

* Dotween

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo7.png"></td>

  </tr>
 </table>

 ```csharp

public class Demo7_Object1 : MonoBehaviour
{
    private void Start()
    {
        Tween tween =
         transform.DOMoveX(2f, 2f)
        .SetRelative(false) // move to relative position
        .SetEase(Ease.OutQuad)
        .SetDelay(5f)
        .SetSpeedBased(false) // zaman yerine hiz
        .SetId("PlayerMove")
        .SetLoops(5, LoopType.Yoyo);

        tween.onComplete = delegate { Debug.Log("onComplete"); };
        tween.onStepComplete = delegate { Debug.Log("onStepComplete"); };
        tween.onKill = delegate { Debug.Log("onKill"); };

        tween.Play();

        transform.DORotate(Vector3.up * 360, 2, RotateMode.FastBeyond360)
            .SetLoops(5, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}

  ```

[👉 Learn more about Dotween](https://yasirkula.com/2018/07/04/unity-dotween-kullanimi/)

  ## Demo 4

* Time class

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo8.png"></td>

  </tr>
 </table>

 ```csharp

public class Demo8 : MonoBehaviour
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

  ```

[👉 Learn more about Time Class](https://docs.unity3d.com/ScriptReference/Time.html)


  ## Demo 5

* Camera - Viewport Rect 

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo9.png"></td>

  </tr>
 </table>



 ## Demo 6

* Scriptable Objects

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo10.png"></td>

  </tr>
 </table>

 ```csharp

[CreateAssetMenu(menuName = "Scriptable Objects/Demo10", fileName = "Demo10", order = 1001)]
public class Demo10 : ScriptableObject
{
    public float period;
}


public class Demo10Manager : MonoBehaviour
{
    public Demo10 demo10;

    private void Start()
    {
        StartCoroutine(DebugLogIEnumerator());
    }

    IEnumerator DebugLogIEnumerator()
    {
        var yieldReturn = new WaitForSeconds(demo10.period);

        while (true)
        {
            yield return yieldReturn;

            Debug.Log("Log");
        }

    }
}

```

[👉 Learn more about Scriptable Object](https://docs.unity3d.com/Manual/class-ScriptableObject.html)



 ## Demo 7

* Vector3.Slerp
* Sun Rise Motion



 ```csharp


public class Run : MonoBehaviour
{

    public Transform sunrise;
    public Transform sunset;

    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;

    void Start()
    {
        // Note the time at the start of the animation.
        startTime = Time.time;
    }

    void Update()
    {
        // The center of the arc
        Vector3 center = (sunrise.position + sunset.position) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0, 10, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        //  transform.position = Vector3.SlerpUnclamped(riseRelCenter, setRelCenter, fracComplete);
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
    }

}

```


  ## Demo 8

* Material
* Standart Shader

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo5.png"></td>

  </tr>
 </table>

[👉 Learn more about Material](https://docs.unity3d.com/ScriptReference/Material.html)

  ## Demo 9

* Particle System

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/main/Assets/_Resources/demo6.png"></td>

  </tr>
 </table>

[👉 Learn more about Particle System](https://docs.unity3d.com/ScriptReference/ParticleSystem.html)


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

