using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 开始游戏按钮功能类
/// </summary>
public class StartButton : MonoBehaviour {
    public GameObject setting, back, music, sound; 
    public SpriteRenderer catspriterenderer;
    void Awake()
    {
        //开始前暂停,以充当开始界面的设计
        Time.timeScale = 0;
    }
    void Start()
    {
        catspriterenderer.enabled = false;
        setting.SetActive(false);
        back.SetActive(false);
    }
    /// <summary>
    /// 单击事件触发
    /// </summary>
    public void choosen()
    {
        Time.timeScale = 1;
        catspriterenderer.enabled = true;
        music.SetActive(false);
        sound.SetActive(false);
        setting.SetActive(true);
        back.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
