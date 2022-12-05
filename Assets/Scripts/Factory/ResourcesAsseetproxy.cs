using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAsseetproxy :IssetFactory
{
  //获得资源工厂的对象引用
  private ResourcesAsseetFacroty assetFactory = new ResourcesAsseetFacroty();
    //声明资源的字典，保存加载的数据，避免加载一样的资源
   
    private Dictionary<string , AudioClip>soundDic = new Dictionary<string, AudioClip>();


    public AudioClip LoadAudioClip(string name)
    {
        throw new System.NotImplementedException();
    }
}
