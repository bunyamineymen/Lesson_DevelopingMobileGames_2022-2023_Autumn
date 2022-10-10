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


