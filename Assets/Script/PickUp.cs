using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform _equip = null;

    private void OnTriggerEnter (Collider other)
    {
        switch (other.tag)
        {
            case "Weapon":
                other.transform.SetParent (_equip);
                other.transform.localPosition = new Vector3 (0, 0, 0);
                other.transform.localRotation = Quaternion.identity;
                break;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Weapon":
                collision.transform.SetParent (_equip);
                break;
        }
    }
}
