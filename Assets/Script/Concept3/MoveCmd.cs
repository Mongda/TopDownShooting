using UnityEngine;
using System.Collections;

public class MoveCmd : Command
{
    private Transform m_transform;
    private float m_moveSpeed;

    public MoveCmd(Transform _transform, float _moveSpeed)
    {
        m_transform = _transform;
        m_moveSpeed = _moveSpeed;
    }

    public void Execute()
    {
        if (Input.GetKey (KeyCode.W))
        {
            m_transform.Translate (Vector3.forward * Time.deltaTime * m_moveSpeed, Space.World);
        }
        else if (Input.GetKey (KeyCode.S))
        {
            m_transform.Translate (Vector3.back * Time.deltaTime * m_moveSpeed, Space.World);
        }
        else if (Input.GetKey (KeyCode.A))
        {
            m_transform.Translate (Vector3.left * Time.deltaTime * m_moveSpeed, Space.World);
        }
        else if (Input.GetKey (KeyCode.D))
        {
            m_transform.Translate (Vector3.right * Time.deltaTime * m_moveSpeed, Space.World);
        }
    }
}
