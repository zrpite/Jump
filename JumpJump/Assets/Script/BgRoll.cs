using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 背景滚动功能类
/// </summary>
public class BgRoll : MonoBehaviour {

	public Transform cat_transform;
	public Vector3 pos;
	public bool canDown = false;
	void Start () 
	{
		pos = this.transform.position;
	}
	
	void FixedUpdate () 
	{
		if(this.transform.position.y >= 0.5f)
		{
			canDown = true;
		}
		if(cat_transform.position.y >= this.transform.position.y + 2.2f)
		{
			StartCoroutine(Up());
		}
		if(cat_transform.position.y <= this.transform.position.y - 1.5f && canDown)
		{	
			StartCoroutine(Down());
		}
	}
	/// <summary>
	/// 向上滚动的协程
	/// </summary>
	IEnumerator Up()
	{
		this.transform.position = Vector3.MoveTowards(this.transform.position,this.transform.position + new Vector3(0,3,0),Time.fixedDeltaTime*3);
		yield return null;
	}
	/// <summary>
	/// 向下滚动的协程
	/// </summary>
	IEnumerator Down()
	{
		this.transform.position = Vector3.MoveTowards(this.transform.position,this.transform.position + new Vector3(0,-3,0),Time.fixedDeltaTime*5);
		yield return null;
	}
}
