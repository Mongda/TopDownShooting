using UnityEngine;
using System.Collections;
using System;

public class Rifle : GunBase
{
    protected override void Reload()
    {
        m_ammo = m_fullAmmo;
        Debug.Log ("Load bullet");
    }

    protected override void Shoot()
    {
        m_ammo -= 1;
        GameObject bullet = Instantiate (m_bullet, m_shootTrans.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
    }
}
