using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private Camera mainCamera;
    private int distanceFromCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        distanceFromCamera = 100;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (ray, out hit, distanceFromCamera))
        {
            Vector3 lookingAtPoint = GetLookingAtPoint (hit.point);
            transform.LookAt (lookingAtPoint);
        }
    }

    private Vector3 GetLookingAtPoint(Vector3 hitPoint) {
        Vector3 lookingAtPoint = hitPoint;
        lookingAtPoint.y = transform.position.y;
        return lookingAtPoint;
    }
}
