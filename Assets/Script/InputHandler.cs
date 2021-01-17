using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public static Action<KeyCode> OnKeyPress = delegate { };
    public static Action<int> OnMousePress = delegate { };
    // Update is called once per frame
    void Update()
    {
        Keyboard ();
        Mouse ();
    }

    private void Keyboard ()
    {
        if (Input.GetKey (KeyCode.W))
        {
            OnKeyPress (KeyCode.W);
        }
        else if (Input.GetKey (KeyCode.S))
        {
            OnKeyPress (KeyCode.S);
        }

        if (Input.GetKey (KeyCode.A))
        {
            OnKeyPress (KeyCode.A);
        }
        else if (Input.GetKey (KeyCode.D))
        {
            OnKeyPress (KeyCode.D);
        }
    }

    private void Mouse()
    {
        if (Input.GetMouseButton (0))
        {
            OnMousePress (0);
        }
    }
}
