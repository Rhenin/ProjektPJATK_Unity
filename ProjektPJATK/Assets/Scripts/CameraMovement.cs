using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Quaternion newRotate;
    Camera cam;
    // Use this for initialization
    void Start () {
        newRotate = Quaternion.Euler(-8.5f, -2.391f, 0f);
        cam = GetComponent<Camera>();
        cam.transform.position = new Vector3(149.5f, 2.2f, 21.8f);
        Camera.main.transform.localRotation = newRotate;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("1"))
        {
            newRotate = Quaternion.Euler(-8.5f, -2.391f, 0f);
            Camera.main.transform.position = new Vector3(149.5f, 2.2f, 21.8f);
            Camera.main.transform.localRotation = newRotate;
        }

        if (Input.GetButtonDown("2"))
        {
            newRotate = Quaternion.Euler(57.17f, -2f, 0f);
            Camera.main.transform.position = new Vector3(149.5f, 9.8f, 27.9f);
            Camera.main.transform.localRotation = newRotate;
        }
        if (Input.GetButtonDown("3"))
        {
            newRotate = Quaternion.Euler(26.01f, 80.8f, 0f);
            Camera.main.transform.position = new Vector3(142.73f, 3.4f, 33.3f);
            Camera.main.transform.localRotation = newRotate;
        }
        if (Input.GetButtonDown("4"))
        {
            newRotate = Quaternion.Euler(41.5f, -102.9f, 0f);
            Camera.main.transform.position = new Vector3(154.19f, 5.5f, 35.1f);
            Camera.main.transform.localRotation = newRotate;
        }
        if (Input.GetButtonDown("5"))
        {
            newRotate = Quaternion.Euler(9.41f, -180f, 0f);
            Camera.main.transform.position = new Vector3(149.02f, 3.43f, 42.14f);
            Camera.main.transform.localRotation = newRotate;
        }

    }
}
