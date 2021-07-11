using UnityEngine;
using System.Collections;
using System;
public class Shotgun : GunBase
{
    protected override void Reload ()
    {
        m_ammo += 1;
        if (m_ammo >= m_fullAmmo)
        {
            m_ammo = m_fullAmmo;
            return;
        }

        PreReload ();
    }

    protected override void Shoot ()
    {
        m_ammo -= 1;
        GameObject bullet = Instantiate (m_bullet, m_shootTrans.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
    }
}
