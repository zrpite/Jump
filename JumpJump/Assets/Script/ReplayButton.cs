using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 重新开始按钮功能类
/// </summary>
public class ReplayButton : MonoBehaviour {
  /// <summary>
  /// 单击事件触发
  /// </summary>
    public void choosen()
    {
        Global.score = 0;
        SceneManager.LoadScene("GameScene");
    }
}
