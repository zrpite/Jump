using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏音效开关类
/// </summary>
public class SetSound : MonoBehaviour {

    public GameObject soundon, soundoff;
    private bool on;
    // Use this for initialization
    void Start()
    {
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            soundon.GetComponent<UI2DSprite>().enabled = true;
            soundoff.GetComponent<UI2DSprite>().enabled = false;
        }
        else
        {
            soundon.GetComponent<UI2DSprite>().enabled = false;
            soundoff.GetComponent<UI2DSprite>().enabled = true;
        }
    }
    /// <summary>
    /// 单击事件触发
    /// </summary>
    public void choose()
    {
        on = !on;
        Global.sound = on;
    }
}
