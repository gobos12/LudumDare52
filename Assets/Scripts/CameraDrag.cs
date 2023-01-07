using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 origin;

    // Update is called once per frame
    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        //save position of mouse in world space where drag starts
        var mousePos = Input.mousePosition;
        mousePos.z = -10;
        if(Input.GetMouseButtonDown(0))
            origin = cam.ScreenToWorldPoint(mousePos);
        //Calculate distance between drag origin and new position
        if(Input.GetMouseButton(0))
        {
            Vector3 difference = origin - cam.ScreenToWorldPoint(mousePos);

            //move the camera by that distance
            cam.transform.position += difference;
        }
    }
}
