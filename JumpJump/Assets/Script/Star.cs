using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 星星功能类
/// </summary>
public class Star : MonoBehaviour {
	public BoxCollider2D colli;
	public Transform cat_transform;
	/// <summary>
	/// 间隔一定时间重新检测是否需要重设位置
	/// </summary>
	private float speed = 0;

	void Update () 
	{
		speed += Time.deltaTime;
		if(speed >= 3)
		{
			speed = 0;
			if(this.transform.position.y - cat_transform.position.y > 6)
			{
				this.transform.position = cat_transform.position + new Vector3(0, 5, 0);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Cat")
		{
			colli.enabled = true;
			this.transform.position += new Vector3(0, 1, 0);
			StartCoroutine(Wait(0.2f));
		}
	}
	IEnumerator Wait(float t)
	{
		yield return new WaitForSeconds(t);
		colli.enabled = false;
	}
}
