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
        if (!ReadyToFire ()) {
            return;
        }

        switch((KeyCode)button)
        {
            case KeyCode.Mouse0:
                {
                    Shoot ();
                }
                break;
        }

        ResetTimer ();
    }

    private bool ReadyToFire() {
        _current += Time.deltaTime;
        if (_current < _interval) {
            return false;
        }

        return true;
    }

    private void Shoot() {
        GameObject bullet = Instantiate (_bullet, _shoot.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
        OnFire (10);
    }

    private void ResetTimer() {
        _current = 0;
    }
}
