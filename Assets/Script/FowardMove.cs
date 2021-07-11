using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardMove : MonoBehaviour
{
    [SerializeField] private float m_speed = 5;
    [SerializeField] private ISpeedData m_speedData = null;
    [SerializeField] private float m_current = 0;
    [SerializeField] private float m_interval = 3;

    private void Start ()
    {
        if (m_speedData == null) return;
        m_speed = m_speedData.GetSpeed ();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.forward * Time.deltaTime * m_speed, Space.Self);

        if(m_current > m_interval)
        {
            Destroy (gameObject);
        }
        m_current += Time.deltaTime;
    }
}
