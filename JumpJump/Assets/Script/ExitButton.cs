using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 结束游戏按钮功能类
/// </summary>
public class ExitButton : MonoBehaviour {
    /// <summary>
    /// 单击事件触发
    /// </summary>
    public void choosen()
    {
        Application.Quit();
    }
}
