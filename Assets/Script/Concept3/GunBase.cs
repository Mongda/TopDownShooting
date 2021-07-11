using UnityEngine;
using System.Collections;
using System;

public abstract class GunBase : Tool
{
    [SerializeField] protected GameObject m_bullet;
    [SerializeField] protected Transform m_shootTrans;

    [SerializeField] private float m_shootInterval;
    [SerializeField] private float m_reloadInterval;
    private float m_interval;
    private float m_elapsedTime;
    private bool m_lock;

    [SerializeField] protected int m_fullAmmo;
    [SerializeField] protected int m_ammo;

    private Action m_command;

    private void Start ()
    {
        m_elapsedTime = 0;
        m_lock = false;
        m_command = delegate { };
        m_ammo = m_fullAmmo;
    }

    private void Update ()
    {
        if (!m_lock)
        {
            return;
        }

        m_elapsedTime += Time.deltaTime;
        if (m_elapsedTime > m_interval)
        {
            m_lock = false;
            m_command?.Invoke ();
        }
    }

    protected override void Execute ()
    {
        if (Input.GetKey (KeyCode.R) && CanReload ())
        {
            PreReload ();
        }
        else if (Input.GetKey (KeyCode.Mouse0) && CanShoot ())
        {
            PreShoot ();
            Shoot ();
        }
    }

    private bool CanReload ()
    {
        return !m_lock && m_ammo < m_fullAmmo;
    }

    private bool CanShoot ()
    {
        return !m_lock && m_ammo > 0;
    }

    protected void PreReload ()
    {
        m_interval = m_reloadInterval;
        m_elapsedTime = 0;
        m_lock = true;
        m_command = null;
        m_command += Reload;
    }

    private void PreShoot ()
    {
        m_interval = m_shootInterval;
        m_elapsedTime = 0;
        m_lock = true;
        m_command = null;
    }

    protected abstract void Reload ();
    protected abstract void Shoot ();
}
