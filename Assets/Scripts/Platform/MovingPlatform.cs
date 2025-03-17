using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] target;
    public float speed = 6f;

    int curPos = 0;
    int nextPos = 1;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target[nextPos].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target[nextPos].position) <= 0)
        {
            curPos = nextPos;
            nextPos++;
            if(nextPos > target.Length - 1)
                nextPos = 0;
        }
    }
}
