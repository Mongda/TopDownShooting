using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private void OnDestroy ()
    {
        Fire.OnFire -= OnFire;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Fire.OnFire += OnFire;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.forward * Time.deltaTime * _speed, Space.Self);
    }

    private void OnFire(float speed)
    {
        _speed = speed;
    }
}
