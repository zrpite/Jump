using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏全局标志位和状态机
/// </summary>
public static class Global  
{
	/// <summary>
	/// 下个砖块生产高度
	/// </summary>
	public static float high ;
	/// <summary>
	/// 砖块中心对齐
	/// </summary>
	public static bool refresh = false;
	public static bool sound = true;
	/// <summary>
	/// 游戏得分
	/// </summary>
	public static int score = 0;
	/// <summary>
	/// 猫状态机
	/// </summary>
	public enum Condition
	{
		STAND,
		UP,
		FALL,
		DIE
	}
}
