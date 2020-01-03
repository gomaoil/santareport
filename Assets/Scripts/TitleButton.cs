using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void LoadLevel1()
    {
        PlayerStatus.Instance.Reset();
        PlayerStatus.Instance.NowLevel = 0;
        SceneManager.LoadScene("lv1");
    }
    public void LoadLevel2()
    {
        PlayerStatus.Instance.Reset();
        PlayerStatus.Instance.NowLevel = 1;
        SceneManager.LoadScene("lv2");
    }
    public void LoadLevel3()
    {
        PlayerStatus.Instance.Reset();
        PlayerStatus.Instance.NowLevel = 2;
        SceneManager.LoadScene("lv3");
    }
}
