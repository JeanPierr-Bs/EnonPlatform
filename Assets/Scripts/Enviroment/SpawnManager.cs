using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static Vector3 lastCheckPointPosition; //Guarda la ultima posicion del checkpoint
    void Start()
    {
        if (lastCheckPointPosition == Vector3.zero)
        {
            lastCheckPointPosition = transform.position;
        }
    }
}
