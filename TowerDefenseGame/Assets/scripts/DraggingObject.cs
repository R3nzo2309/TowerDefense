using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingObject : MonoBehaviour
{

    private bool isBeingDragged;

    private void OnMouseDown()
    {
        isBeingDragged = true;
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
    }

    private void Update()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (isBeingDragged)
        {
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
}
