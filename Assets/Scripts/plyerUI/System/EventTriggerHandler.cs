using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Button = UnityEngine.UIElements.Button;



public class EventTriggerHandler
{
    private GameObject buttn;

   
    // Use this for initialization
    void Start()
    {
       buttn=GameObject.Find("usemange");
    
        EventTrigger trigger = buttn.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        // 鼠标点击事件
        entry.eventID = EventTriggerType.PointerClick;
        // 鼠标进入事件
        entry.eventID = EventTriggerType.PointerEnter;
        // 鼠标滑出事件 entry.eventID = EventTriggerType.PointerExit;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(OnClick);
      entry.callback.AddListener (OnMouseEnter);
        trigger.triggers.Add(entry);
    }

    public void Click()
    {    
    }

    public Action<bool> butimestop;
    private void OnClick(BaseEventData pointData)
    {
       
        butimestop(false);
    }

    private void OnMouseEnter(BaseEventData pointData)
    {
        Debug.Log("Button Enter. EventTrigger..");
    }
}