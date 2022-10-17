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
