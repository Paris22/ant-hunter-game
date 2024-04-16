using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float _delayToDestroy = 3f;

    private void Start()
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(_delayToDestroy);
        Destroy(gameObject);
    }
}
