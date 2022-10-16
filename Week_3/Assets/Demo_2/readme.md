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
    <td><img src="https://raw.githubusercontent.com/bunyamineymen/Lesson2_DevelopingMobileGame/Week_3/Assets/_Resources/demo1_1.png"></td>

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