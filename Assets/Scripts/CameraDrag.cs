using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    //Variables for camera pan
    [SerializeField]
    private Camera cam;
    private Vector3 origin;

    //Variables to set limitors for camera pan
    [SerializeField]
    private Canvas canvas;
    private float canvasHeight;
    private float canvasWidth;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();

        canvasHeight = canvas.GetComponent<RectTransform>().rect.height;
        canvasWidth = canvas.GetComponent<RectTransform>().rect.width;

        mapMinX = canvas.transform.position.x - canvasWidth / 2f;
        mapMaxX = canvas.transform.position.x + canvasWidth / 2f;

        mapMinY = canvas.transform.position.y - canvasHeight / 2f;
        mapMaxY = canvas.transform.position.y + canvasHeight / 2f;
    }    

    // Update is called once per frame
    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        //save position of mouse in world space where drag starts
        var mousePos = Input.mousePosition;
        mousePos.z = cam.transform.position.z;

        //Allows for panning when holding the middle button
        // if(Input.GetMouseButtonDown(2))
        //     origin = cam.ScreenToWorldPoint(mousePos);
        // print(cam.ScreenToWorldPoint(mousePos));
        // //Calculate distance between drag origin and new position
        // if(Input.GetMouseButton(2))
        // {
        //     Vector3 difference = origin - cam.ScreenToWorldPoint(mousePos);

        //     //move the camera by that distance
        //     cam.transform.position = ClampCamera(cam.transform.position + difference);
        //     //print(ClampCamera(cam.transform.position + difference));
        //     //cam.transform.position += difference;
        // }
        //print(cam.ScreenToWorldPoint(mousePos));
        //print(mousePos);

        //Measures how far the mouse is from the center
        origin = new Vector3(220, 125, cam.transform.position.z);
        Vector3 difference = mousePos - origin;

        //Pan camera if mouse is too far from center
        if(difference.x < -150 || difference.x > 150 || difference.y < -80 || difference.y > 80)
        {
            difference.x /= 10;
            difference.y /= 10;
            
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }
        
    }

    //Stops camera from panning if it goes out of bounds
    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        //print(camWidth);

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
