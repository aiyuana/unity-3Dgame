using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadState : ISceneState
{
    public LoadState(SceneContorl sceneContorl) : base("Loding", sceneContorl) { }
    private Image mLoadBar;//加载进度条
    private Text timelood;
    float waitTime = 0;//和进度条绑定时间
    float AllTime = 100;
    public override void StateStart()
    {
        
        mLoadBar = GameObject.Find("Loadpar").GetComponent<Image>();
        timelood = GameObject.Find("TIME").GetComponent<Text>();
    }
    public override void StateUpdate()
    {
        
        waitTime += Time.deltaTime*20;
        mLoadBar.fillAmount = waitTime / AllTime;
        timelood.text = ((int)waitTime).ToString();
        if (waitTime >= AllTime)
        {
            mController.Setstate(new GameState(mController));
        }
      
    }
}