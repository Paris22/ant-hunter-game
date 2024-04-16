using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehaviour : MonoBehaviour
{
    [SerializeField, Range(0.5f, 5f)]
    private float _speed = 2f;

    [SerializeField, Range(0.5f, 5f)]
    private float _eatDelay = 2f;

    [SerializeField]
    private GameObject _deathEffect;

    private Target _target;
    void Start()
    {
        _target = FindObjectOfType<Target>();
    }

    
    void Update()
    {
        var direction = _target.transform.position - transform.position;
        transform.position += direction.normalized * _speed * Time.smoothDeltaTime;
        
        var vectorToTarget = _target.transform.position - transform.position;
        var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        var quaternion = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = quaternion;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_target == col.GetComponent<Target>())
        {
            _speed = 0;
            StartCoroutine(EatRoutine());
        }
    }

    private void OnMouseDown()
    {
        if (_deathEffect != null)
            Instantiate(_deathEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private IEnumerator EatRoutine()
    {
        while (true)
        {
            _target.Eat();
            yield return new WaitForSeconds(_eatDelay);
        }
    }
}
