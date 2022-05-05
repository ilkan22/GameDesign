using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doCameraControl = false;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = -85f;
    public float maxX = -25f;
    public float minZ = 0f;
    public float maxZ = 70f;


    // Update is called once per frame
    void Update()
    {
        //CameraControl AN/AUS
        if (Input.GetKeyDown(KeyCode.Escape))
            doCameraControl = !doCameraControl;

        if (!doCameraControl)
            return;

        //Kamerebewegung um 90Grad gedreht weil das Level von der Haupkamera gedreht ist
        //Deswegen "w" Vector3.right e.t.c
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
      
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        //Scrollen
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        //Zommen durch scrollen
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        //Rand Restriktion der Kamera
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
