using UnityEngine;

namespace Pattern.FactoryMethod
{
    public class Shopowner : INPC
    {
        public void Speak()
        {
            Debug.Log("Shopowner: Do you wish to purchase something?");
        }
    }
}