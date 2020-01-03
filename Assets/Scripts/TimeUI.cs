using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    private const int kLevel = 0;
    Animator _animater;
    Slider _slider;
    [SerializeField]
    float[] _limitSecond;
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        _animater = GetComponent<Animator>();
        _slider = GetComponent<Slider>();
        _animater.SetBool("TimeBarInOut", true);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _slider.value = Mathf.Clamp01(_time / _limitSecond[kLevel]);
    }

    public bool IsTimeUp { get { return _limitSecond[kLevel] <= _time; } }
}
