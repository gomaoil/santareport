using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextWindow : MonoBehaviour, IPointerClickHandler {

    Animator _animator;
    GimmickKind _kind;
    GimmickData _nowGimmickData;
    Text _text;
    CinemachineVirtualCamera _objectCamera;
    int _textNum;

    public void OnPointerClick(PointerEventData data)
    {
        var isExistText = ToNextText();
        if (!isExistText)
        {
            _animator.SetBool("MessageInOut", false);
            PlayerStatus.Instance.Add(_kind);
            _objectCamera.Priority = 0;
        }
    }

    private bool ToNextText()
    {
        ++ _textNum;
        switch (_textNum)
        {
            case 1:
                if (_nowGimmickData.text1 == null || _nowGimmickData.text1 == "") { return false; }
                _text.text = _nowGimmickData.text1;
                break;
            case 2:
                if (_nowGimmickData.text2 == null || _nowGimmickData.text2 == "") { return false; }
                _text.text = _nowGimmickData.text2;
                break;
            case 3:
                if (_nowGimmickData.text3 == null || _nowGimmickData.text3 == "") { return false; }
                _text.text = _nowGimmickData.text3;
                break;
            case 4:
                if (_nowGimmickData.text4 == null || _nowGimmickData.text4 == "") { return false; }
                _text.text = _nowGimmickData.text4;
                break;
            case 5:
                if (_nowGimmickData.text5 == null || _nowGimmickData.text5 == "") { return false; }
                _text.text = _nowGimmickData.text5;
                break;
            default:
                return false;
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _text = GetComponentInChildren<Text>();
        _objectCamera = FindObjectsOfType<CinemachineVirtualCamera>().FirstOrDefault(c => c.Priority == 0);
        _objectCamera.Follow = null;
        _objectCamera.LookAt = null;
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal void SetKind(GimmickKind kind)
    {
        _kind = kind;
        _nowGimmickData = GimmickDataList.Instance.DataList[(int)kind];
        _text.text = _nowGimmickData.text1;
        _textNum = 1;
    }
}
