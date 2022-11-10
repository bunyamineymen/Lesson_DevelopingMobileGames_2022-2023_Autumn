
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


 </table>

 [👉 Learn more about Physics Layer](https://docs.unity3d.com/Manual/LayerBasedCollision.html)





# Demo 3 

## Project Oriented Demo

We are handling input - motion - ui flow - restart - effect in this demo.

These scripts have motion and input behaviours.

```csharp

public class SwerveMovement : MonoBehaviour
{

    [SerializeField]
    private SwerveInputSystem swerveInputSystem;

    [SerializeField]
    private float swerveSpeed = 0.5f;

    [SerializeField]
    private float maxSwerveAmount = 1f;

    private void Update()
    {

        float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.MoveFactoryX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0f, 0f);

    }


}

```

```csharp

public class SwerveInputSystem : MonoBehaviour
{

    private float _lastFrameFingerPositionX;
    private float _moveFactoryX;

    public float MoveFactoryX { get => _moveFactoryX; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;

            _moveFactoryX = currentMousePosition.x - _lastFrameFingerPositionX;

            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactoryX = 0f;
        }
    }

}

```

```csharp

    private bool canMotion = true;
    public bool CanMotion { get => canMotion; set => canMotion = value; }


    public float VelocityOfPlayer;

    public GameObject Effect;


    private void FixedUpdate()
    {
        if (!canMotion)
            return;

        transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * VelocityOfPlayer;

        if (transform.position.x > 0.466f)
        {
            transform.position = new Vector3(0.466f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -0.466f)
        {
            transform.position = new Vector3(-0.466f, transform.position.y, transform.position.z);
        }

    }

```

<table>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo_3_2.PNG"></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo_3_3.PNG"></td>
  </tr>

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_5/Assets/_Resources/demo_3_4.PNG"></td>
  </tr>


 </table>

## Resources

- [:book: Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html)
- [:book: Rotate](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html)

## Next Lesson Topics

- Project core mechanic demo



