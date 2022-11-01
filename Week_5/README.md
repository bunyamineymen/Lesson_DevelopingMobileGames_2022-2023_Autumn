
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 5

Developing Mobile Game lesson for Ankara university - Week 5

# Demo 1 
## Rigidbody Example

Rigidbody is a component which allows GameObjects to connect with physics engine.
With rigidbody; you can make a gameobject collidable, gravity dependent and force effectible.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo1_1.png"></td>
  </tr>

 </table>


[👉 Learn more about Rigidbody](https://docs.unity3d.com/ScriptReference/Rigidbody.html)

# Demo 2
## Physics Layer

Layer-based collision detection is a way to make a GameObject collide with another GameObject that is set up to a specific Layer or Layers.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo2.png"></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo2_2.png"></td>
  </tr>

 </table>

 [👉 Learn more about Physics Layer](https://docs.unity3d.com/Manual/LayerBasedCollision.html)





# Demo 3 
## Gravity Example

Unity handles collision between GameObjects with colliders, which attach to GameObjects and define the shape of a GameObject
 for the purposes of physical collisions. A collider is invisible, and does not need to be the exact same shape as the GameObject’s mesh
. A rough approximation of the mesh is often more efficient and indistinguishable in gameplay.

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo3_1.png"></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/3_2.png"></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/3_3.png"></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo3_4.png"></td>
  </tr>

 </table>

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

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_4/Assets/_Resources/sunRise.png" width=540></td>

  </tr>
 </table>


 ## Demo 8


# Demo 8
## Ragdolls

### * What is ragdoll ?
Ragdoll is basically a unity feature that allow us to make character physics more realistic.
With ragdoll, we can apply force to our character and make it much more realistic than animations.
In the past, most of game development companies are developed death, swing or flying away animations for using in action.
But with ragdoll technology, we just need to break animation, set active the ragdoll and applying the force.
And remain is will be handled by game engine.
Ofcourse most of game engines has ragdoll feature. Its not limited with unity.

### * How does ragdoll works ?
Now, lets explain ragdoll concept with what we learned from our lesson.
As you know, a rigged body has many parts for providing bending to joints.
Basically, if you need wave your character's hand in unity, you need to add riggs for your shoulder,
arm, forearm (And fingers, if extra functionallity and gestures needed)
Ragdoll mechanism in unity, basically adds rigidbody with mess (calculated due to body-part size) and collider by mesh.
This allows our character to fall like a connected chain.

### * How to create ragdoll by using Unity Editor ?
First of all, you have to select your character in editor. And after that, right click on the gameobject and select 3D Object> Create Ragdoll

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo8_1.png"></td>
  </tr>

And after that, a pop-up menu like this will welcome you. You can add your character model parts with correct matching.
You can see the correct ragdoll connection below.

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo8_2.png"></td>
  </tr>

Also, all of mixamo models will work properly with this ragdoll connection settings.
After clicking "Create" button, game engine will automatically add rigidbody and collider each of our character parts.
Please don't change any of this collider and rigidbody component's attributes. Because they will calculated in runtime by game engine.

So; our next question is :

### * How to disable ragdoll programmatically ?
For example, we are working on a game and our character should die realistic. What should we do ?
First of all, we need to assign ragdoll on runtime. Ofcourse you can use 3rd party assets for dealing with this.
But in our lesson, we will do it by iterating each colliders and rigidbody components of our character.

Basically, we need 13 different body parts for creating a ragdoll. That means, we will have 13 different rigidbody and collider components
after ragdoll creation. So; we can disable our ragdoll with making them inactive or removed.
But we need to repeat, if you have a intend to re-use your object later, please don't remove ragdoll. Just make it inactive until you need ragdoll again.

 ```csharp
public Rigidbody[] rigidbodies = new Rigidbody[13];
public Collider[] colliders = new Collider[13];
public CharacterJoint[] chJoints = new CharacterJoint[13];
//assign them in editor
 
foreach Rigidbody rb in rigidbodies
   rb.useGravity = false; //true if you want to enable ragdoll
 
foreach Collider coll in colliders
   coll.enabled = false; //true if you want to enable ragdoll
 
foreach CharacterJoint joint in chJoints
   joint.enabled = false; //true if you want to enable ragdoll
```

Also remember ! We don't need rigidbody component each every part of our character's body. We just need it when realistic joint movement needed.
So, in your standart game flow, you will not need ragdoll. It is only required for death, collusion, crashing, explosion and etc.



## Resources

- [:book: Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html)
- [:book: Rotate](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html)

## Next Lesson Topics

- Transform
- Input
- Motion


