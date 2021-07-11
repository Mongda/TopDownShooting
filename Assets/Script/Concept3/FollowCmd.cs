using UnityEngine;
using System.Collections;

public class FollowCmd : Command
{
    private Transform m_target;
    private Transform m_self;
    private float m_moveSpeed;

    public FollowCmd(Transform _self, Transform _target, float _moveSpeed)
    {
        m_self = _self;
        m_target = _target;
        m_moveSpeed = _moveSpeed;
    }
    

    public void Execute()
    {
        MoveToTarget ();
        FacingTarget ();
    }

    private void MoveToTarget()
    {
        float step = m_moveSpeed * Time.deltaTime;
        m_self.position = Vector3.MoveTowards (m_self.position, m_target.transform.position, step);
    }

    private void FacingTarget()
    {
        Vector3 lookRotation = m_target.transform.position - m_self.position;
        if (lookRotation != Vector3.zero)
        {
            m_self.forward = lookRotation;
        }
    }
}
