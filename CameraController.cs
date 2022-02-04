using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float _sens = 200.0f;
    public Transform player;
    private float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*_sens*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*_sens*Time.deltaTime;

        xRotation -= mouseY; // gdyby było += to byłaby odwrócona oś myszki
        xRotation = Mathf.Clamp(xRotation, -90, 90.0f); // ograniczenie, aby nie można było odwrócić się przez plecy
        player.Rotate(Vector3.up * mouseX); // vector3.up reprezentuje os Y wokol ktorej (lewo/prawo) chcemy poruszac ruszajac myszka lewo/prawo
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);//zmiana rotacji elementu do ktorego przypisany
        //jest skrypt
    }
}
