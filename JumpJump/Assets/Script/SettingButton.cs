using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 设置按钮功能类
/// </summary>
public class SettingButton : MonoBehaviour 
{
    public GameObject music,sound,back;
    /// <summary>
    /// 单击事件触发
    /// </summary>
    public void Choose()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(false);
        back.SetActive(true);
        music.SetActive(true);
        sound.SetActive(true);
    }
}
