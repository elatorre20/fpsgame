using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //set mouse sensitivity
    public float mouseSensitivity = 100f;
    //reference alignment to player body
    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse x (horizontal)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //get mouse y (vertical
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity* Time.deltaTime;

        //rotate camera
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
