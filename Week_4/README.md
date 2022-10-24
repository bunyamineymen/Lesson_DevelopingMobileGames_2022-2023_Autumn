
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

[👉 Learn more about Rigidbody](https://docs.unity3d.com/ScriptReference/Rigidbody.html)

# Demo 2
## Colliders

Unity handles collision between GameObjects with colliders, which attach to GameObjects and define the shape of a GameObject
 for the purposes of physical collisions. A collider is invisible, and does not need to be the exact same shape as the GameObject’s mesh
. A rough approximation of the mesh is often more efficient and indistinguishable in gameplay.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_4/Assets/_Resources/demo2.png"></td>

  </tr>
 </table>

 [👉 Learn more about Rigidbody](https://docs.unity3d.com/ScriptReference/Collider.html)

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

```csharp

public class Demo3 : MonoBehaviour
{
    public GameObject gameobject;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Rigidbody rigidbody = gameobject.GetComponent<Rigidbody>();
            rigidbody.useGravity = !rigidbody.useGravity;
        }
    }
}

```

 [👉 Learn more about Gravity](https://docs.unity3d.com/ScriptReference/Physics-gravity.html)

# Demo 4

## Physic Material

The Physic Material adjusts friction and bouncing effects of colliding GameObjects.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_4/Assets/_Resources/demo4_1.png" width = 600></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_4/Assets/_Resources/demo4_2.png"></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_4/Assets/_Resources/demo4_3.png"></td>
  </tr>

 </table>

To create a Physic Material, select Assets > Create > Physic Material from the menu bar. Then drag the Physic Material from the Project View onto a Collider in the scene.

 [👉 Learn more about Physics Material](https://docs.unity3d.com/Manual/class-PhysicMaterial.html)

# Demo 5

## Raycast

Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.

```csharp

public class Demo5_1 : MonoBehaviour
{

    public GameObject duckBody;
    public GameObject laserMachine;
    public int RotationSpeed = 5;
    public int laserLength = 15;

    public Material redMaterial;
    public Material defaultMaterial;

    Ray ray;
    RaycastHit hit;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rotateLaserMachine(0.1f);
        }

        //float mouseAxis = Input.GetAxis("Mouse X");
        duckBody.GetComponent<MeshRenderer>().material = defaultMaterial;
        handleRaycast(laserMachine);
    }

    void rotateLaserMachine(float axis)
    {
        laserMachine.transform.Rotate(
            0,
            (axis * RotationSpeed),
            0,
            Space.World
       );
    }

    void handleRaycast(GameObject handler)
    {
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(handler.transform.position, handler.transform.TransformDirection(Vector3.forward) * 15, Color.red);
        if (Physics.Raycast(handler.transform.position, laserMachine.transform.TransformDirection(Vector3.forward), out hit, laserLength))
        {
            if (hit.transform.gameObject.name == "Duck")
            {
                duckBody.GetComponent<MeshRenderer>().material = redMaterial;
                Debug.Log("We hit the duck !");
            }

        }
    }
}

```

 [👉 Learn more about Raycast](https://mobidictum.biz/unity-raycast/)



  ## Demo 6

* Camera - Viewport Rect 

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_4/Assets/_Resources/viewportRect.png"></td>

  </tr>
 </table>

 [👉 Learn more about Viewport Rect ](https://answers.unity.com/questions/1194103/how-can-i-change-the-viewport-rect-of-two-active-c.html)


 ## Demo 7

* Vector3.Slerp
* Sun Rise Motion

 ```csharp

public class Demo7 : MonoBehaviour
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

## Resources

- [:book: Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html)
- [:book: Rotate](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html)

## Next Lesson Topics

- Transform
- Input
- Motion


