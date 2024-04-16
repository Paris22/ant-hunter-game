using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int _startPoints = 10;

    private int _points;

    private TMP_Text _text;

    private void Start()
    {
        _points = _startPoints;
        _text = GetComponentInChildren<TMP_Text>();

        UpdateText();
    }
    
    public void Eat()
    {
        _points--;
        UpdateText();

        if (_points > 0) return;
        
        foreach (var ant in FindObjectsOfType<AntBehaviour>())
            Destroy(ant.gameObject);
        Debug.LogError("Вы проиграли!");

    }

    private void UpdateText()
    {
        if (_text != null)
            _text.text = _points.ToString();
    }
}
