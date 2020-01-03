using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(MeshCollider))]
public class ReactionObject : MonoBehaviour, IPointerClickHandler {

    Animator _messageWindowAnimator;
    TextWindow _textWindow;
    CinemachineVirtualCamera _objectCamera;
    [SerializeField]
    GimmickKind _kind;
    

    // [SerializeField]
    // Animator _objectAnimator;
    public void OnPointerClick(PointerEventData data)
    {
        if (_textWindow != null)
        {
            _textWindow.SetKind(_kind);
        }
        if (_messageWindowAnimator != null) { _messageWindowAnimator.SetBool("MessageInOut", true); }
        _objectCamera.Priority = 20;
        _objectCamera.Follow = this.transform;
        _objectCamera.LookAt = this.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _messageWindowAnimator = FindObjectOfType<Canvas>().transform.Find("MessageBase").GetComponent<Animator>();
        _objectCamera = FindObjectsOfType<CinemachineVirtualCamera>().FirstOrDefault(c => c.Priority == 0);
        UnityEngine.Debug.Assert(_messageWindowAnimator != null, "MessageBase not Found");
        _textWindow = _messageWindowAnimator.GetComponent<TextWindow>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    

}
