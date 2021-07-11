using UnityEngine;
using System.Collections;

public abstract class Tool : MonoBehaviour, SceneObject
{
    private bool m_using;

    private void Start ()
    {
        m_using = false;
    }

    public void Pickup(Transform _equipTrans)
    {
        m_using = true;
        transform.SetParent (_equipTrans);
        transform.localPosition = new Vector3 (0, 0, 0);
        transform.localRotation = Quaternion.identity;
    }

    public void Drop(Transform _collectTrans)
    {
        m_using = false;
        transform.SetParent (_collectTrans);
    }

    public void Use()
    {
        if (m_using)
        {
            Execute ();
        }
    }

    protected abstract void Execute ();
}
