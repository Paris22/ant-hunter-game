using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenRandomPositionGenerator : MonoBehaviour, IRandomPositionGenerator
{
    [SerializeField, Range(0, 5f)]
    private float randomRadius;

    private float radiusAroundCamera;
    private void Start()
    {
        radiusAroundCamera = Camera.main.GetRadiusAroundCamera();
    }
    
    public Vector3 GetRandomPosition()
    {
        var generatedRadius = radiusAroundCamera + Random.Range(0, randomRadius);
        var x = Random.Range(-generatedRadius, generatedRadius);
        var y = Mathf.Sqrt(generatedRadius * generatedRadius - x * x) * Mathf.Sign(Random.Range(-1, 1));
        return new Vector2(x, y);
    }
}

public interface IRandomPositionGenerator
{
    Vector3 GetRandomPosition();
}
