using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _presentSelect;
    [SerializeField]
    GameObject _report;
    [SerializeField]
    TextMeshProUGUI _reportText;
    [SerializeField]
    GameObject _result;
    [SerializeField]
    Animator _resultAnimator;
    [SerializeField]
    TextMeshProUGUI _reportScore;

    static readonly int[] kCorrectPresentNum = { 7, 4, 3 };

    TimeUI _timer;
    bool _isStartedTimeUpSequence;
    bool _isPresentSelected;
    bool _isReportRead;
    bool _isResultEnd;
    int _presentId;

    public void ToPresentSelected(int presentId)
    {
        _isPresentSelected = true;
        _presentId = presentId;
    }

    public void ToReportRead()
    {
        _isReportRead = true;
    }

    public void ToReultEnd()
    {
        _isResultEnd = true;
    }

    void Start()
    {
        _timer = FindObjectOfType<TimeUI>();
    }

    void Update()
    {
        if (!_isStartedTimeUpSequence && _timer.IsTimeUp)
        {
            StartCoroutine(TimeUpSequence());
        }
    }

    IEnumerator TimeUpSequence()
    {
        _isStartedTimeUpSequence = true;

        FindObjectOfType<Canvas>().transform.Find("MessageBase").gameObject.SetActive(false);
        FindObjectOfType<Canvas>().transform.Find("Slider").gameObject.SetActive(false);
        var activeObjectCamera = FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>().FirstOrDefault(c => c.Priority == 20);
        if (activeObjectCamera != null) { activeObjectCamera.Priority = 0; }

        string reportText = PlayerStatus.Instance.CreateReport();
        _reportText.SetText(reportText);

        _reportScore.SetText($"スコア{PlayerStatus.Instance.NowScore}点！");
        _report.SetActive(true);
        while (!_isReportRead) { yield return null; }
        _report.SetActive(false);

        _presentSelect.SetActive(true);
        while (!_isPresentSelected) { yield return null; }
        _presentSelect.SetActive(false);

        _result.SetActive(true);
        CulcultateResult();
        while (!_isResultEnd) { yield return null; }

        SceneManager.LoadScene("Title");

    }

    private void CulcultateResult()
    {
        if (PlayerStatus.Instance.NowScore <= 80)
        {
            _resultAnimator.SetInteger("Result", 0 + PlayerStatus.Instance.NowLevel * 3);
        }
        else
        {
            if (kCorrectPresentNum[PlayerStatus.Instance.NowLevel] == _presentId)
            {
                PlayerStatus.Instance.NowScore += 50;
            }

            if (101 <= PlayerStatus.Instance.NowScore)
            {
                _resultAnimator.SetInteger("Result", 2 + PlayerStatus.Instance.NowLevel * 3);
            }
            else if (80 < PlayerStatus.Instance.NowScore)
            {
                _resultAnimator.SetInteger("Result", 1 + PlayerStatus.Instance.NowLevel * 3);
            }
            else
            {
                _resultAnimator.SetInteger("Result", 0 + PlayerStatus.Instance.NowLevel * 3);
            }
        }
    }
}
