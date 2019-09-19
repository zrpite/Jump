using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 设置返回按钮功能
/// </summary>
public class Back : MonoBehaviour {
    public GameObject setting,music,sound;
    /// <summary>
    /// 事件触发函数
    /// </summary>
	public void choose()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        setting.SetActive(true);
        music.SetActive(false);
        sound.SetActive(false);
    }
}
