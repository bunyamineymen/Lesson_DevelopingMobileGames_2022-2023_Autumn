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
[[img 8_1]]

And after that, a pop-up menu like this will welcome you. You can add your character model parts with correct matching.
You can see the correct ragdoll connection below.
[[img 8_2]]
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

