using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Fire : MonoBehaviour
{
    [SerializeField] private Transform _shoot = null;
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private float _interval = 0.1f;

    private float _current = 0;
    
    public static Action<float> OnFire = delegate { };

    private void Start ()
    {
        InputHandler.OnMousePress += OnMousePress;
        _current = _interval;
    }

    private void OnDestroy ()
    {
        InputHandler.OnMousePress -= OnMousePress;
    }

    private void OnMousePress(int button)
    {
        _current += Time.deltaTime;
        if (_current < _interval)
            return;

        switch(button)
        {
            case 0:
                {
                    GameObject bullet = Instantiate (_bullet, _shoot.position, Quaternion.identity);
                    bullet.transform.rotation = transform.rotation;
                    OnFire (10);
                    _current = 0;
                }
                break;
        }
    }
}
