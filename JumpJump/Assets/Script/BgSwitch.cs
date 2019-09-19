using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 根据事件切换背景功能类
/// </summary>
public class BgSwitch : MonoBehaviour {

	public SpriteRenderer spriterender; 
	public Sprite[] bg;
	/// <summary>
	/// 频率
	/// </summary>
	public float speed	= 8;
	private float i_s = 0;
	private int choose = 0;
	// Use this for initialization
	void Start ()
	{
		i_s = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		print(i_s);
		i_s += Time.deltaTime;
		if(i_s >= speed)
		{
			i_s = 0;
			spriterender.sprite = bg[choose];
			++choose;
			if(choose > 2)
				choose = 0;
		}
	}
}
