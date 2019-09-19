using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏音乐开关类
/// </summary>
public class SetMusic : MonoBehaviour {

    public GameObject musicon, musicoff;
    private bool on;
    public AudioSource bk;
	// Use this for initialization
	void Start () 
    {
        on = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (on)
        {
            musicon.GetComponent<UI2DSprite>().enabled = true;
            musicoff.GetComponent<UI2DSprite>().enabled = false;
        }
        else
        {
            musicon.GetComponent<UI2DSprite>().enabled = false;
            musicoff.GetComponent<UI2DSprite>().enabled = true;
        }
    }
    /// <summary>
    /// 单击事件触发
    /// </summary>
    public void choose()
    {
        on = !on;
        if (on)
        {
            bk.Play();
        }
        else
            bk.Stop();
    }
}
