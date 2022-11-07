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
