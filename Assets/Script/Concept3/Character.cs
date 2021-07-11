using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour, DamagableObject
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private int m_health;

    [SerializeField] private Transform m_equipTrans = null;
    [SerializeField] private Transform m_collectTrans = null;
    private Tool m_tool = null;

    private List<Command> m_commands = null;
    private Rigidbody m_rigibody = null;

    private void Start ()
    {
        m_moveSpeed = 1.0f;
        m_commands = new List<Command> ();
        m_commands.Add (new MoveCmd (transform, m_moveSpeed));
        m_commands.Add (new TurnCmd (transform));
        m_rigibody = GetComponent<Rigidbody> ();
    }

    private void Update ()
    {
        foreach(Command cmd in m_commands)
        {
            cmd.Execute ();
        }

        UseTool ();
    }

    private void UseTool ()
    {
        if (!m_tool)
        {
            return;
        }

        m_tool.Use ();
    }

    private void OnTriggerStay (Collider other)
    {
        if (!Input.GetKeyUp (KeyCode.E))
        {
            return;
        }


        Tool tool = other.GetComponent<Tool> ();
        if (tool == null)
        {
            return;
        }

        PickupTool (tool);
    }

    private void PickupTool(Tool _tool)
    {
        Tool newTool = _tool;
        if (newTool == null)
        {
            return;
        }

        if (m_tool)
        {
            m_tool.Drop (m_collectTrans);
        }

        m_tool = newTool;
        m_tool.Pickup (m_equipTrans);
    }

    public void GetDamage (float _force, Vector3 _direction, int _damage)
    {
        m_rigibody.AddForce (_direction * _force);
        DealDamage (_damage);
    }

    private void DealDamage (int _damage)
    {
        m_health -= _damage;
        if (m_health < 0)
        {
            m_health = 0;
            Destroy (gameObject);
        }
    }
}
