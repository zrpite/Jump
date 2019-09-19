using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 砖块逻辑控制类
/// </summary>
public class BrickControl : MonoBehaviour {
	public Rigidbody2D rb;
	private CatControl catcontrol;
	public float speed = 2f;
	/// <summary>
	/// 砖块可否移动标志位
	/// </summary>
	public bool canMove = true;
	/// <summary>
	/// 砖块是否第一次出来标志位
	/// </summary>
	public bool birthing = true;
	/// <summary>
	/// 可否居中标志位
	/// </summary>
	public bool canFresh = false;
	/// <summary>
	/// 砖块分数
	/// </summary>
	public int grade = 100;
	/// <summary>
	/// 能否加分标志位
	/// </summary>
	public bool canscore = true;
	/// <summary>
	/// 用于刷新位置的目标中间位置
	/// </summary>
	private Vector3 tarPos;
	void Start () 
	{
		catcontrol = GameObject.Find("Cat").GetComponent<CatControl>();
		birthing = true;
		canFresh = false;
	}
	void FixedUpdate () 
	{
		if(canMove)
			DoMove();
		if(canFresh)
			DoFresh();
		
	}
	/// <summary>
	/// 方块不断向x正移动
	/// </summary>
	void DoMove()
	{
		transform.Translate(new Vector2(Time.fixedDeltaTime * speed, 0));
	}
	/// <summary>
	/// "所有"方块居中
	/// </summary>
	void DoFresh()
	{
		this.transform.position = Vector3.MoveTowards(this.transform.position,tarPos,Time.fixedDeltaTime*2);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Cat")
		{
			if(catcontrol.state == Global.Condition.FALL)
			{
				if(canscore)
				{
					Global.score += grade;
					canscore = false;
				}
				birthing = false;
				canMove = false;
				rb.bodyType = RigidbodyType2D.Dynamic;
				catcontrol.state = Global.Condition.STAND;
			}
			if(birthing && catcontrol.state == Global.Condition.STAND)
			{
				print("横撞而死");
				catcontrol.state = Global.Condition.DIE;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Refresh")
		{
			tarPos = new Vector3(0,this.transform.position.y,0);
			canFresh = true;
			StartCoroutine(Wait(0.2f));
		}
	}
	IEnumerator Wait(float t)
	{
		yield return new WaitForSeconds(t);
		canFresh = false;
	}
}
