using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//状态模式
public class ISceneState 
{
    //需要加载场景名字
    private string mSceneName;
    //场景状态管理
    protected SceneContorl mController;
    public string MScenename { get => mSceneName; set => mSceneName = value; }
    public ISceneState(string sceneName,SceneContorl sceneContorl)
    {
        mSceneName = sceneName;
        mController = sceneContorl;
    }
    //每次进入状态时候调用
    public virtual void StateStart() { }
    //在这个状态下每帧更新的信息
    public virtual void StateUpdate() { }
    //离开这个状态的调用
    public virtual void StateEnd() { }
}