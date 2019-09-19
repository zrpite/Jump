using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 砖块生成器
/// </summary>
public class BrickSpawn : MonoBehaviour {

	/// <summary>
	/// 要生成的砖块
	/// </summary>
	public GameObject[] brick;
	/// <summary>
	/// 生成频率
	/// </summary>
	public float speed = 3;
	private float i_s = 4;
	private float s_x = -3, s_y = 0.17f;//+0.075f
	private Vector2 pos;
	private int r = 1;
	// Use this for initialization
	void Start ()
	{
		i_s = speed;
		r = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		i_s -= Time.deltaTime;
		if(i_s <= 0)
		{
			i_s = speed;
			
			RandomInstantiate();
			s_x *= -1;
			transform.RotateAround(transform.position,transform.forward,180);
		}
	}
	/// <summary>
	/// 随机生成砖块
	/// </summary>
	void RandomInstantiate()
	{
		if(Time.time < 10)
		{
			r = Random.Range(1,5);
		}
		else
		{
			r = Random.Range(1,7);
		}
		if(r == 5 || r == 6)
			pos = new Vector2(s_x, Global.high + 0.1f);
		else
			pos = new Vector2(s_x, Global.high - s_y);
		Instantiate(brick[r-1], pos, this.transform.rotation);
	}

}

