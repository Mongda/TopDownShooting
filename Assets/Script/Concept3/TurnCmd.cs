using UnityEngine;
using System.Collections;

public class TurnCmd : Command
{
    private Camera m_camera;
    private Transform m_transform;

    public TurnCmd(Transform _transform)
    {
        m_camera = Camera.main;
        m_transform = _transform;
    }


    public void Execute()
    {
        RaycastHit hit;
        Ray ray = m_camera.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (ray, out hit, 100))
        {
            Vector3 point = hit.point;
            point.y = m_transform.position.y;
            m_transform.LookAt (point);
        }
    }
}
