using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target = null;
    [SerializeField] float _distance = 10;

    private void Update ()
    {
        Vector3 end = _target.position;
        end.y += _distance;
        transform.position = Vector3.Lerp (transform.position, end, Time.time);
    }
}
