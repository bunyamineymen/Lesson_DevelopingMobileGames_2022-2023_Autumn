using UnityEngine;

namespace Pattern.FactoryMethod
{
    public class Farmer : INPC
    {
        public void Speak()
        {
            Debug.Log("Farmer: You reap what you sow!");
        }
    }
}
