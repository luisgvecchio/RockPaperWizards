using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 mousePosition;

    bool getPosition = true;
    
    void Update()
    {
        CheckMouseClick();
    }
    private void FixedUpdate()
    {
        ChangePosition(mousePosition);
    }

    private void CheckMouseClick()
    {
        if (Input.GetMouseButton(0) && getPosition)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
        }
    }

    public void ChangePosition(Vector3 movement)
    {
            transform.position = Vector3.Lerp(transform.position, movement, 0.05f);
    }

    public void GetPositionFalse()
    {
        getPosition = false;
    }
        public void GetPositionTrue()
    {
        getPosition = true;
    }
}
