using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        InputHandler.OnKeyPress += OnKeyPress;
    }

    private void OnDestroy ()
    {
        InputHandler.OnKeyPress -= OnKeyPress;
    }

    private void OnKeyPress (KeyCode code)
    {
        switch(code)
        {
            case KeyCode.W:
                transform.Translate (Vector3.forward * Time.deltaTime * _speed, Space.World);
                break;
            case KeyCode.S:
                transform.Translate (Vector3.back * Time.deltaTime * _speed, Space.World);
                break;
            case KeyCode.A:
                transform.Translate (Vector3.left * Time.deltaTime * _speed, Space.World);
                break;
            case KeyCode.D:
                transform.Translate (Vector3.right * Time.deltaTime * _speed, Space.World);
                break;
        }
    }
}
