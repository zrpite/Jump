using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 把猫下方一定高度的方块刚体属性改成Kinematic(防止倒塌太多)
/// </summary>
public class UnderSetKine : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Brick")
		{
			other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		}
	}
}
