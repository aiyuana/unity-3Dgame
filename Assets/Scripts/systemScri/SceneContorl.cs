using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneContorl
{
    //场景当前状态
    private ISceneState msceneState;
    //异步操作符 场景使用加载
    private AsyncOperation mAo;
    private bool mIsRunStart;

    //设置场景状态
    public void Setstate(ISceneState state, bool isLoadScene = true)
    {
        //场景初始状态为空如果不是第一次进入则把上一个场景状态资源释放
        if (msceneState!=null  )
        {
            msceneState.StateEnd();
        }
        //更新当前场景状态
        msceneState = state;
        //判断是否需要加载
        if (isLoadScene)
        {
            //需要加载
            mAo=  SceneManager.LoadSceneAsync(msceneState.MScenename);
            mIsRunStart = false;
          
        }
        else
        {
            //不需要加载
            msceneState.StateStart();
            mIsRunStart = true;

        }

    }
    //状态实时更新内容
    public void StateUpdate()
    {
        if (mAo != null && mAo.isDone == false) return;
        if (mAo!=null && mAo.isDone && mIsRunStart==false)
        {
            msceneState.StateStart();
            mIsRunStart = true;
        }
        if (msceneState != null)
            msceneState.StateUpdate();
    }
}