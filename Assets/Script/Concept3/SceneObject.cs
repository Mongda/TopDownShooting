using UnityEngine;
using System.Collections;

public interface SceneObject
{
    void Pickup (Transform _equipTrans);
    void Drop (Transform _collectTrans);
}


public interface Command
{
    void Execute ();
}

public interface DamagableObject
{
    void GetDamage (float _force, Vector3 _direction, int _damage);
}