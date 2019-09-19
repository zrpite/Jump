using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 猫控制器
/// </summary>
public class CatControl : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rb;
	public AudioSource au;
	public AudioClip jump,die,lose;
	public BoxCollider2D colli;
	/// <summary>
	/// 猫死亡特效
	/// </summary>
	public GameObject explore;
	public Global.Condition state = Global.Condition.FALL;
	/// <summary>
	/// 起跳速度
	/// </summary>
	public float speed = 13;
	/// <summary>
	/// 跳起中间速度
	/// </summary>
	public float i_s = -1;
	private bool oncetimedie = true;
	// Use this for initialization
	void Start () 
	{
		oncetimedie = true;
		state = Global.Condition.FALL;
		i_s = -1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(state)
		{
			case Global.Condition.FALL : Fall(); break;
			case Global.Condition.STAND : Stand(); break;
			case Global.Condition.UP : Up(); break;
			case Global.Condition.DIE : Die(); break;
		}
	}
	/// <summary>
	/// 下落状态执行
	/// </summary>
	void Fall()
	{
		//下降过程选用重力控制
		rb.bodyType = RigidbodyType2D.Dynamic;
		anim.SetBool("Jump",false);
		anim.SetBool("Idle",false);
		anim.SetBool("Fall",true);
	}
	/// <summary>
	/// 站立状态执行
	/// </summary>
	void Stand()
	{
		anim.SetBool("Fall",false);
		anim.SetBool("Idle",true);
		Global.high = this.transform.position.y;
		if(GetClick())
		{
				//选择在准备跳跃前一刻重设i_s值,这样在跳起前i_s值为负,可区分砖块倒塌情况和自主跳起情况
				i_s = speed;
				state = Global.Condition.UP;
				//播放跳起音效
				if(Global.sound)
					au.PlayOneShot(jump);
		}
	}
	/// <summary>
	/// 上升状态执行
	/// </summary>
	void Up()
	{
		DoJump();
		//逻辑上i_s<=0即为下落状态,刻意使之为负,以得到更明显的逻辑区分
		if(i_s <= -0.1f)
		{
			state = Global.Condition.FALL;
		}
	}
	/// <summary>
	/// 死亡状态执行
	/// </summary>
	void Die()
	{
		if(oncetimedie)
		{
			oncetimedie = false;
			au.PlayOneShot(lose);
			anim.SetBool("Die",true);
			Instantiate(explore,this.transform.position,this.transform.rotation);
			colli.enabled = false;	
			rb.bodyType = RigidbodyType2D.Dynamic;
			StartCoroutine(Wait(2));
		}
	}
	/// <summary>
	/// 场景切换协程
	/// </summary>
	/// <param name="t"></param>
	/// <returns></returns>
	IEnumerator Wait(float t)
	{
		yield return new WaitForSeconds(t);
		SceneManager.LoadScene("OverScene");
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Brick")
		{
			// if(state == Condition.STAND)
			// {
			// 	print("横撞而死");
			// 	state = Condition.DIE;
			// }
			if(state == Global.Condition.FALL)
			{
				print("站稳");
				state = Global.Condition.STAND;
			}
			if(state == Global.Condition.UP)
			{
				print("顶死");
				state = Global.Condition.DIE;
			}
		
		}
	}
	void OnCollisionStay2D(Collision2D other)
	{
		if(state == Global.Condition.FALL)
		{
			state = Global.Condition.STAND;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		//这里是砖块倒塌情况的判断
		if(i_s <= 0)
		{
			state = Global.Condition.FALL;
		}
	}
	/// <summary>
	/// 返回单击事件
	/// </summary>
	/// <returns></returns>
	bool GetClick()
	{
		return (Input.GetMouseButtonDown(0));
	}
	/// <summary>
	/// 跳跃实现
	/// </summary>
	void DoJump()
	{
		//上升过程脚本控制
		rb.bodyType = RigidbodyType2D.Kinematic;
		anim.SetBool("Idle",false);
		anim.SetBool("Jump",true);
		transform.Translate(new Vector3(0, Time.deltaTime * i_s, 0));
		i_s -= 0.5f;
	}
}
