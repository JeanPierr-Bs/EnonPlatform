using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosePlatform : MonoBehaviour
{
    private float WaitToFall = 1f;
    private float WaitToDestroy = 2f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Drop());
        }
    }
    private IEnumerator Drop()
    {
        yield return new WaitForSeconds(WaitToFall);
        rb.useGravity = enabled;
        Destroy(this.gameObject,WaitToDestroy);
    }
}
