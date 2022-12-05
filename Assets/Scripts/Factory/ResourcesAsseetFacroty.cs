using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//资源工厂动态加载
public class ResourcesAsseetFacroty : IssetFactory
{
    
    public string SoundPath1 = "Audio";
   
    
   

    public AudioClip LoadAudioClip(string name)
    {
        string path = "";
        
        
        return  Resources.Load<AudioClip>(path + name);
    }

    private GameObject LoadGameobject(string path)
    {
        Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("无法加载路径"+path);
            return null;
        }
        return  GameObject.Instantiate(o)as GameObject;
    }
//提供给代理对象使用加载资源只需要获得资产不需要实例化在场景里面
    public object LoadAsset(string path)
    {
        Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("无法加载路径"+path);
            return null;
        }

        return o;
    }

}