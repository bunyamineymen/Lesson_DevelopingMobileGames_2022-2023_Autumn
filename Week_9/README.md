
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 9

Developing Mobile Game lesson for Ankara university - Week 9

# Demo 1

## Editor Example

```csharp

public class Cube : MonoBehaviour {

	void Start ()
	{
		GenerateColor();
	}

	public void GenerateColor ()
	{
		GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
	}

	public void Reset ()
	{
		GetComponent<Renderer>().sharedMaterial.color = Color.white;
	}

}

```

```csharp

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor {

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Cube cube = (Cube)target;

		GUILayout.BeginHorizontal();

			if (GUILayout.Button("Generate Color"))
			{
				cube.GenerateColor();
			}

			if (GUILayout.Button("Reset"))
			{
				cube.Reset();
			}

		GUILayout.EndHorizontal();
	}

}

```







```csharp

using UnityEngine;

public class Sphere : MonoBehaviour {

	public float baseSize = 1f;

	void Update ()
	{
		float animation = baseSize + Mathf.Sin(Time.time * 8f) * baseSize / 7f;
        transform.localScale = Vector3.one * animation;
	}

}

```

```csharp

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Sphere))]
public class SphereEditor : Editor {

	public override void OnInspectorGUI()
	{
		Sphere sphere = (Sphere)target;

		GUILayout.Label("Oscillates around a base size.");

		sphere.baseSize = EditorGUILayout.Slider("Size", sphere.baseSize, .1f, 2f);

		sphere.transform.localScale = Vector3.one * sphere.baseSize;
	}

}

```

# Demo 2

## Editor Example

```csharp

public class Pipe : MonoBehaviour
{
    [SerializeField] private float startingCapacity = 100;
    [SerializeField] private float maxCapacity = 500;

    public float Capacity { get; private set; }

    private void Awake()
    {
        Capacity = startingCapacity;
    }

    public void AddFluid(float amount)
    {
        Capacity = Mathf.Clamp(amount, 0, maxCapacity);
    }
}


```

```csharp

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Pipe))]
public class PipeEditor : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        IMGUIContainer defaultInspector = new IMGUIContainer(() => DrawDefaultInspector());

        root.Add(defaultInspector);
        root.Add(new Label("Part Selection")
        {
            style =
            {
                marginTop = 10,
                marginBottom = 4,
                unityFontStyleAndWeight = FontStyle.Bold
            }
        });
        root.Add(CreatePartButtons());
        root.Add(new Label("Rotation")
        {
            style =
            {
                unityFontStyleAndWeight = FontStyle.Bold,
                marginBottom = 4,
            }
        });
        root.Add(CreateRotateButtons());
        return root;
    }

    private VisualElement CreatePartButtons()
    {
        VisualElement partButtons = new VisualElement()
        {
            style =
            {
                flexDirection = FlexDirection.Row,
                justifyContent = Justify.Center,
                marginBottom = 10,
                paddingTop = 5,
                paddingBottom = 5,
                borderBottomLeftRadius = 10,
                borderTopLeftRadius = 10,
                backgroundColor = new Color(0.3f, 0.3f, 0.3f)
            }
        };

        VisualElement straightPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Straight.prefab"))
        {
            text = "Straight Part"
        };
        
        VisualElement cornerPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Corner.prefab"))
        {
            text = "Corner Part"
        };
        
        VisualElement intersectionPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Intersection.prefab"))
        {
            text = "Intersection Part"
        };
        
        VisualElement ioPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-IO.prefab"))
        {
            text = "IO Part"
        };
        
        VisualElement tankPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Tank.prefab"))
        {
            text = "Tank Part"
        };
        
        partButtons.Add(straightPartButton);
        partButtons.Add(cornerPartButton);
        partButtons.Add(intersectionPartButton);
        partButtons.Add(ioPartButton);
        partButtons.Add(tankPartButton);

        return partButtons;
    }

    private VisualElement CreateRotateButtons()
    {
        VisualElement rotateButtons = new VisualElement()
        {
            style =
            {
                flexDirection = FlexDirection.Row,
                justifyContent = Justify.Center,
                marginBottom = 10,
                paddingTop = 5,
                paddingBottom = 5,
                borderBottomLeftRadius = 10,
                borderTopLeftRadius = 10,
                backgroundColor = new Color(0.3f, 0.3f, 0.3f)
            }
        };

        Button rotateRightButton = new Button(() => Rotate(90))
        {
            text = ">"
        };
        
        Button rotateLeftButton = new Button(() => Rotate(-90))
        {
            text = "<"
        };
        
        Button rotateOpposite = new Button(() => Rotate(180))
        {
            text = "O"
        };
        
        rotateButtons.Add(rotateLeftButton);
        rotateButtons.Add(rotateOpposite);
        rotateButtons.Add(rotateRightButton);
        return rotateButtons;
    }

    private void SetModel(string assetPath)
    {
        Pipe pipe = (Pipe) serializedObject.targetObject;
        Transform head = pipe.transform.Find("Head");

        foreach (Transform child in head)
        {
            DestroyImmediate(child.gameObject);
        }

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        GameObject gameObject = (GameObject) PrefabUtility.InstantiatePrefab(prefab);
        gameObject.transform.SetParent(head, false);
    }

    private void Rotate(float degrees)
    {
        Pipe pipe = (Pipe) serializedObject.targetObject;
        pipe.transform.Find("Head").Rotate(0, degrees, 0);
    }
}

```

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
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_9/Assets/_Resources/demo777.png"></td>
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
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_9/Assets/_Resources/demo8_1.png"></td>
  </tr>

And after that, a pop-up menu like this will welcome you. You can add your character model parts with correct matching.
You can see the correct ragdoll connection below.

  <tr>
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson_DevelopingMobileGames/main/Week_9/Assets/_Resources/demo8_2.png"></td>
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


