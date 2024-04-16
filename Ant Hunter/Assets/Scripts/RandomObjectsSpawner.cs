using System;
using System.Collections;
using UnityEngine;

public class RandomObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnedObject;
    
    [SerializeField, Range(0.1f, 5f)]
    private float _startObjectsDelay = 3f;
    
    [SerializeField, Range(0.1f, 2f)]
    private float _ultimateObjectsDelay = 0.5f;
    
    [SerializeField, Range(0.01f, 5f)]
    private float _delayStep = 0.1f;

    private IRandomPositionGenerator _randomPositionGenerator;

    private Coroutine _spawnRoutine;

    private void Start()
    {
        _randomPositionGenerator = GetComponent<IRandomPositionGenerator>();
        if (_randomPositionGenerator == null)
            throw new SystemException("Пожалуйста, добавьте на объект игровой логики RandomPositionGenerator!");

        _spawnRoutine = StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        var delay = _startObjectsDelay;
        while (true)
        {
            Instantiate(_spawnedObject, _randomPositionGenerator.GetRandomPosition(), Quaternion.identity);
            yield return new WaitForSeconds(delay);
            delay -= _delayStep;
            if (delay < _ultimateObjectsDelay)
                delay = _ultimateObjectsDelay;
        }
    }
}
