
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

## Movement Example

```csharp

public class Demo3 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character_1;
    public float forcePower;
    Rigidbody character_1_rigidbody;

    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    void Update()
    {
        freeMovement();
    }

    void freeMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            character_1_rigidbody.AddForce(Vector3.left * forcePower);
        if (Input.GetKey(KeyCode.RightArrow))
            character_1_rigidbody.AddForce(Vector3.right * forcePower);
        if (Input.GetKey(KeyCode.W))
            character_1_rigidbody.AddForce(Vector3.forward * forcePower);
        if (Input.GetKey(KeyCode.S))
            character_1_rigidbody.AddForce(Vector3.back * forcePower);
        if (Input.GetKey(KeyCode.UpArrow))
            character_1_rigidbody.AddForce(Vector3.up * forcePower);
        if (Input.GetKey(KeyCode.DownArrow))
            character_1_rigidbody.AddForce(Vector3.down * forcePower);

    }
}


```

# Demo 4

## Jump Example

```csharp

public class Demo4 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character_1;
    public float forcePower = 2.5f;
    public float RotationSpeed = 5;
    Rigidbody character_1_rigidbody;

    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    void Update()
    {
        relativeMovement();
        relativeRotation();
        jumpMovement();
    }

    void relativeMovement()
    {

        if (Input.GetKey(KeyCode.W))
            character_1_rigidbody.AddForce(character_1.transform.up * forcePower);
        if (Input.GetKey(KeyCode.S))
            character_1_rigidbody.AddForce(character_1.transform.up * forcePower * -1);
        if (Input.GetKey(KeyCode.D))
            character_1_rigidbody.AddForce(character_1.transform.right * forcePower );
        if (Input.GetKey(KeyCode.A))
            character_1_rigidbody.AddForce(character_1.transform.right * forcePower * -1);
    }

    void jumpMovement()
    {
        if (Input.GetKey(KeyCode.Space))
            character_1_rigidbody.AddForce(character_1.transform.forward * forcePower);
    }

    void relativeRotation() 
    {
        float mouseAxis = Input.GetAxis("Mouse X");
        character_1.transform.Rotate(
              0,
              (mouseAxis * RotationSpeed),
              0,
              Space.World
         );
    }
}


```

# Demo 5

## AddExplosionForce Command

Applies a force to a rigidbody that simulates explosion effects.

The explosion is modelled as a sphere with a certain centre position and radius in world space; normally, anything outside the sphere is not affected by the explosion and the force decreases in proportion to distance from the centre. However, if a value of zero is passed for the radius then the full force will be applied regardless of how far the centre is from the rigidbody.

```csharp

public class Demo5 : MonoBehaviour
{
    public GameObject bomb;
    public float bombRadius = 5.0F;
    public float bombPower = 700.0F;
    public float bombModifier = 3.0F;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            explode();
        }
    }

    void explode()
    {
        GameObject bombMuzzle = bomb.transform.GetChild(0).gameObject;
        bombMuzzle.transform.SetParent(this.gameObject.transform);
        bombMuzzle.SetActive(true);
        Vector3 explosionPos = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, bombRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(bombPower, explosionPos, bombRadius, bombModifier);
        }
        bomb.SetActive(false);
    }
}


```

 [👉 Learn more about AddExplosionForce](https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html)



  ## Demo 6

In this demo we understand to importance of ragdoll system .

```csharp

public class Demo6 : MonoBehaviour
{
    public GameObject bomb;
    public GameObject ragdoll;
    public float bombRadius = 5.0F;
    public float bombPower = 400.0F;
    public float bombModifier = 3.0F;
    public bool slowMotion = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slowMotion)
            Time.timeScale = 0.5F;
        else
            Time.timeScale = 1;
        if (Input.GetKeyDown("space"))
        {
            explode();
        }
    }

    void explode()
    {

        GameObject bombMuzzle = bomb.transform.GetChild(0).gameObject;
        GameObject ragdollArmature = ragdoll.transform.GetChild(0).gameObject;
        

        bombMuzzle.transform.SetParent(this.gameObject.transform);
        bombMuzzle.SetActive(true);
        ragdollArmature.SetActive(true);

        Vector3 explosionPos = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, bombRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(bombPower, explosionPos, bombRadius, bombModifier);
        }
        bomb.SetActive(false);
    }
}


```

 [👉 Learn more about Ragdoll](https://docs.unity3d.com/Manual/wizard-RagdollWizard.html)


 ## Demo 7

In this demo we understand to need of ragdoll system.

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo7.png"></td>
  </tr>

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


