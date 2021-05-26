using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{

    [SerializeField]
    private HealthBehavior _health;
    private Slider _slider;
    [SerializeField]
    private Gradient _HealthGradient;

    [SerializeField]
    private Image _fill;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health.Health;
        _fill.color = _HealthGradient.Evaluate(1f);

    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _health.Health;
        _fill.color = _HealthGradient.Evaluate(_slider.value / _slider.maxValue);
    }
}
