using UnityEngine;
using System.Collections.Generic;

public class Monster : MonoBehaviour, DamagableObject
{
    [SerializeField] private int m_health;
    [SerializeField] private Transform m_target;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_force;
    [SerializeField] private int m_damage;

    private List<Command> m_commands;
    private Rigidbody m_rigibody;
    
    // Use this for initialization
    void Start ()
    {
        m_commands = new List<Command> ();
        m_rigibody = GetComponent<Rigidbody> ();

        m_commands.Add (new FollowCmd (transform, m_target, m_moveSpeed));
    }

    // Update is called once per frame
    void Update ()
    {
        foreach (Command cmd in m_commands)
        {
            cmd.Execute ();
        }
    }

    public void GetDamage(float _force, Vector3 _direction, int _damage)
    {
        m_rigibody.AddForce (_direction * _force);
        DealDamage (_damage);
    }

    private void DealDamage(int _damage)
    {
        m_health -= _damage;
        if(m_health < 0)
        {
            m_health = 0;
            Destroy (gameObject);
        }
    }

    private void OnTriggerStay (Collider other)
    {
        DamagableObject damagableObject = other.GetComponent<DamagableObject> ();
        if (damagableObject == null)
        {
            return;
        }

        Vector3 forceDirection = GetForceDirection (other.transform.position);
        damagableObject.GetDamage (m_force, forceDirection, m_damage);
    }



    private Vector3 GetForceDirection (Vector3 _target)
    {
        return _target - transform.position;
    }
}
