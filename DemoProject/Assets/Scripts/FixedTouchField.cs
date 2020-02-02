using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public Vector2 touchDistance;

    [HideInInspector]
    public Vector2 PntrOld;

    [HideInInspector]
    protected int PntrId;

    [HideInInspector]
    public bool pressed;


    void Start()
    {
        
    }

    void Update()
    {

        if(pressed)
        {
            if (PntrId > 0 && PntrId < Input.touches.Length)
            {
                touchDistance = Input.touches[PntrId].position - PntrOld;
                PntrOld = Input.touches[PntrId].position;
            }
            else
            {
                touchDistance = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PntrOld;
                PntrOld = Input.mousePosition;
            }
        }
        else
        {
            touchDistance = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventdata)
    {
        pressed = true;
        PntrId = eventdata.pointerId;
        PntrOld = eventdata.position;
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        pressed = false;
    }


}
