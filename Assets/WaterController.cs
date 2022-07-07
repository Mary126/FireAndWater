using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject Fire;
    IEnumerator DestroyFire()
    {
        yield return new WaitForSeconds(3);
        Destroy(Fire);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DestroyFire());
    }
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(DestroyFire());
    }
}
