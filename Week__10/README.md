
<!-- # ![mg-builder](/img~/mg-builder.png) -->

# Lesson 10

Developing Mobile Game lesson for Ankara university - Week 10

# Demo 1

## Manipulate Material and Simple Movement

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube;
    public float forcePower = 50;
    public float rotatePower= 100;
    public float jumpPower = 20;


    public Material[] materialList;

    private Rigidbody cube_rigidbody;
    private int rightClickCounter;
    void Start()
    {
        cube_rigidbody = cube.GetComponent<Rigidbody>();
    }

    void Update()
    {
        axisMovement();
        wheelMovement();
        clickMovement();
    }

    void axisMovement()
    {
        float X = Input.GetAxis("Mouse X");
        float Y = Input.GetAxis("Mouse Y");
        cube_rigidbody.AddForce(Vector3.left * forcePower * X * -1);
        cube_rigidbody.AddForce(Vector3.forward * forcePower* Y);
    }


    void wheelMovement()
    {
        float scroll = Input.mouseScrollDelta.y;
        cube.transform.Rotate(new Vector3(0, rotatePower, 0) * scroll);
    }

    void clickMovement()
    {
        if (Input.GetMouseButton(0))    //While MS each pressed
            cube_rigidbody.AddForce(Vector3.up * jumpPower);
        if (Input.GetMouseButtonDown(1)) //While once pressed
            this.changeMaterial();
            
    }

    private void changeMaterial()
    {
        rightClickCounter++;
        int index = rightClickCounter % materialList.Length;
        cube.GetComponent<MeshRenderer>().material = materialList[index];
    }

   
}

```

# Demo 2

## Input - Movement - Jumping

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character_1;
    public float forcePower = 10;
    Rigidbody character_1_rigidbody;

    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    void Update()
    {
        keyboardMovement();
        jumpMovement();
    }

    void keyboardMovement()
    {

        if (Input.GetKey(KeyCode.W))
            character_1_rigidbody.AddForce(character_1.transform.forward * forcePower);
        if (Input.GetKey(KeyCode.S))
            character_1_rigidbody.AddForce(character_1.transform.forward * forcePower * -1);
        if (Input.GetKey(KeyCode.D))
            character_1_rigidbody.AddForce(character_1.transform.right * forcePower );
        if (Input.GetKey(KeyCode.A))
            character_1_rigidbody.AddForce(character_1.transform.right * forcePower * -1);
    }

    void jumpMovement()
    {
        if (Input.GetKey(KeyCode.Space))
            character_1_rigidbody.AddForce(character_1.transform.up * forcePower * 2.5f);
    }
}

```


# Demo 3 

## 

```csharp

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Demo1_3 : MonoBehaviour
{
    public GameObject character_1;
    public GameObject duck_ass;
    public Camera main_camera;
    public Material egg_material;
    public float egg_spawn_power = 800;
    public float movement_power = 10;
    public float Rotation_speed = 5;
    public float wheel_factor = 0.5f;
    Rigidbody character_1_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        keyboardMovement();
        jumpMovement();
        EggControl();
        mouseMovement();
        wheelMovement();
    }



    void keyboardMovement()
    {

        if (Input.GetKey(KeyCode.W))
            character_1_rigidbody.AddForce(character_1.transform.forward * movement_power);
        if (Input.GetKey(KeyCode.S))
            character_1_rigidbody.AddForce(character_1.transform.forward * movement_power * -1);
        if (Input.GetKey(KeyCode.D))
            character_1_rigidbody.AddForce(character_1.transform.right * movement_power);
        if (Input.GetKey(KeyCode.A))
            character_1_rigidbody.AddForce(character_1.transform.right * movement_power * -1);
    }

    void jumpMovement()
    {
        if (Input.GetKey(KeyCode.Space))
            character_1_rigidbody.AddForce(character_1.transform.up * movement_power * 0.95f);
    }

    void EggControl()
    {
        if (Input.GetMouseButtonDown(0))
            createEgg();
    }

    void createEgg()
    {
        GameObject egg = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        egg.name = "An egg";
        egg.AddComponent<SphereCollider>();
        egg.AddComponent<Rigidbody>();
        egg.AddComponent<MeshRenderer>();
        egg.GetComponent<MeshRenderer>().material = egg_material;

        Vector3 egg_throw_position = duck_ass.transform.position;
        egg.transform.position = egg_throw_position;
        egg.GetComponent<Rigidbody>().mass = 1;
        egg.GetComponent<Rigidbody>().AddForce(egg.transform.forward * egg_spawn_power * -1);
    }

    void mouseMovement()
    {
        float mouseAxis = Input.GetAxis("Mouse X");
        character_1.transform.Rotate(
            0,
            (mouseAxis * Rotation_speed),
            0,
            Space.World
       );
    }

    void wheelMovement()
    {
        Vector3 camera_position = main_camera.transform.position;
        camera_position.y += Input.mouseScrollDelta.y * wheel_factor * -1;
        main_camera.transform.position = camera_position;
    }
}


```

# Demo 4

## Change Camera

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_4 : MonoBehaviour
{

    public Camera[] camera_list;

    int camera_id = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraController();
    }

    void cameraController()
    {
        if(Input.GetMouseButtonDown(0))
        {
            changeCamera();
        }
    }

    void changeCamera()
    {
        camera_id++;
        int index = camera_id % camera_list.Length;
        for(int i = 0; i< camera_list.Length; i++)
            camera_list[i].gameObject.SetActive(false);

        camera_list[index].gameObject.SetActive(true);
    }

}


```

# Demo 5

## Camera Movement

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1_5 : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera main_camera;

    public float movement_speed = 10f;
    public float rotation_speed = 2.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse_movement();
        keyboard_movement();
    }

    void mouse_movement()
    {
        float mouseAxisX = Input.GetAxis("Mouse X");
        float mouseAxisY = Input.GetAxis("Mouse Y");
        main_camera.transform.Rotate(
            (mouseAxisY * rotation_speed *-1),
            (mouseAxisX * rotation_speed ),
            0,
            Space.World
       );
        float z = main_camera.transform.eulerAngles.z;
        main_camera.transform.Rotate(0, 0, -z);

    }
   
    void keyboard_movement()
    {
        Vector3 camera_pos = main_camera.transform.position;
        if(Input.GetKey(KeyCode.W))
            camera_pos += main_camera.transform.forward  + new Vector3(movement_speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
            camera_pos += main_camera.transform.forward *-1 + new Vector3(movement_speed * Time.deltaTime * -1, 0, 0);
        if (Input.GetKey(KeyCode.A))
            camera_pos += main_camera.transform.right *-1 + new Vector3(0, movement_speed * Time.deltaTime *-1, 0);
        if (Input.GetKey(KeyCode.D))
            camera_pos += main_camera.transform.right + new Vector3(0, movement_speed * Time.deltaTime, 0);
        main_camera.transform.position = camera_pos;
    }
}

```

# Demo 6

## Joystic Movement

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo5_2 : MonoBehaviour
{

    public VirtualJoystick joystick;
    public GameObject character_1;
    public float movement_power = 5f;
    Rigidbody character_1_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        character_1_rigidbody = character_1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JoystickMovement();
    }

    void JoystickMovement()
    {
        if(joystick.InputDir != Vector2.zero)
        {
            character_1_rigidbody.AddForce(character_1.transform.forward * movement_power * joystick.InputDir.y *-1 );
            character_1_rigidbody.AddForce(character_1.transform.right * movement_power * joystick.InputDir.x * -1);
        }
     
    }

}


```

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    public Image background;
    public Image joystick;
    public float offsetX = 0.3f;
    public float offsetY = 0.7f;
    public Vector2 InputDir;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        float backgroundSizeX = background.rectTransform.sizeDelta.x;
        float backgroundSizeY = background.rectTransform.sizeDelta.y;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform,eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= backgroundSizeY;
            pos.y /= backgroundSizeY;
            InputDir = new Vector2(pos.x, pos.y);
            InputDir = InputDir.magnitude > 5 ? InputDir.normalized * 5: InputDir;
            joystick.rectTransform.anchoredPosition = new Vector2(InputDir.x * (backgroundSizeX / offsetX), InputDir.y * (backgroundSizeY / offsetY));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDir = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


```

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class VirtualTouchpad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool keyY = false;
    public bool keyX = false;
    public bool keyA = false;
    public bool keyB = false;
    public GameObject ButtonY;
    public GameObject ButtonX;
    public GameObject ButtonA;
    public GameObject ButtonB;


    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject touchedObject = eventData.pointerCurrentRaycast.gameObject;
        keyY = (touchedObject == ButtonY || touchedObject.transform.parent.gameObject == ButtonY);
        keyX = (touchedObject == ButtonX || touchedObject.transform.parent.gameObject == ButtonX);
        keyA = (touchedObject == ButtonA || touchedObject.transform.parent.gameObject == ButtonA);
        keyB = (touchedObject == ButtonB || touchedObject.transform.parent.gameObject == ButtonB);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        keyY = false;
        keyX = false;
        keyA = false;
        keyB = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}


```




## Resources

- [:book: Ragdoll](https://docs.unity3d.com/Manual/wizard-RagdollWizard.html)

## Next Lesson Topics

- Joint
- Cloth


