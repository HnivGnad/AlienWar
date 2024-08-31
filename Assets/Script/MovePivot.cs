using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePivot : MonoBehaviour
{
    [SerializeField] float speedRotate = 50f;
    [SerializeField] float minRotate, maxRotate;
    void Start()
    {
        
    }

    void Update()
    {
        MoveWeapon();
    }
    void MoveWeapon() {
        float verticalInput = Input.GetAxis("Vertical");
        float rotationZ = verticalInput * speedRotate * Time.deltaTime;

        float currentRotateZ = transform.rotation.eulerAngles.z;
        if(currentRotateZ > 180) {
            currentRotateZ -= 360;
        }

        float newRotateZ = Mathf.Clamp(currentRotateZ + rotationZ, minRotate, maxRotate);

        transform.rotation = Quaternion.Euler(0, 0, newRotateZ);
    }
}
