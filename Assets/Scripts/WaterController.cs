using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject Fire;
    private bool _isOnFire;
    IEnumerator DestroyFire()
    {
        yield return new WaitForSeconds(3);
        if (_isOnFire)
        {
            Destroy(Fire);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _isOnFire = true;
        StartCoroutine(DestroyFire());

    }
    private void OnTriggerExit(Collider other)
    {
        _isOnFire = false;
        StopCoroutine(DestroyFire());
    }
}
