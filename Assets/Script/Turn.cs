using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (ray, out hit, 100))
        {
            Vector3 point = hit.point;
            point.y = transform.position.y;
            transform.LookAt (point);
        }
    }
}
