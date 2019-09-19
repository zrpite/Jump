using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏内分数更新
/// </summary>
public class Score : MonoBehaviour {
	void Start () {
        this.GetComponent<UILabel>().text = Global.score.ToString();
	}
	void Update () {
        this.GetComponent<UILabel>().text = Global.score.ToString();
    }
}
