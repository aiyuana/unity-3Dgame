using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameState : ISceneState
{
    public GameState(SceneContorl sceneContorl) : base("Game", sceneContorl)
    {
    }

    private Transform mUIRoot;
    private Transform uesmange;
    private Transform masege;
    private Text name;
    private Text sexy;
    private Text age;
    private Text leve;
    private Text uesr;

    public override void StateStart()
    {
        Init();
        MyOnEnable();
        sqlstats.Instance.mangerss = (n, s, a, lv) =>
        {
            name.text = (n);
            uesr.text = (n);
            sexy.text = (s);
            age.text = (a).ToString();
            leve.text = (lv);
        };
    }

    private void Init()
    {
        mUIRoot = GameObject.Find("playerUI").transform;
        uesmange = mUIRoot.Find("Playermange");
        masege = mUIRoot.Find("Manages");
        uesr = mUIRoot.Find("name").GetComponent<Text>();
        name = masege.GetChild(0).GetComponent<Text>();
        sexy = masege.GetChild(1).GetComponent<Text>();
        age = masege.GetChild(2).GetComponent<Text>();
        leve = masege.GetChild(3).GetComponent<Text>();
    }

    private void MyOnEnable()
    {
      
        List<Button> ButtonList = new List<Button>();
        ButtonList.AddRange(uesmange.GetComponentsInChildren<Button>()); //添加整个列表元素到列表里面
        foreach (Button button in ButtonList)
        {
            button.onClick.AddListener(() =>
            {
               ButtonClick(button);

            });
        }
        List<Button> ButtonList1 = new List<Button>();
        ButtonList1.AddRange(masege.GetComponentsInChildren<Button>()); //添加整个列表元素到列表里面
        foreach (Button button in ButtonList1)
        {
            button.onClick.AddListener(() =>
            {
                ButtonClick(button);

            });
        }   

       

    }
    //模式管理场景的按钮
    public static Action<bool> time;
    
    private void ButtonClick(Button sender)
    {

        switch (sender.name)
        {
            case "usemange":
            {
                time.Invoke(true);
               sqlstats.Instance.readdate();
              
               
               
            }

                break;
            case "back":
            {
                time.Invoke(false);
                Time.timeScale = 1;
            }
                break;
            default:
                break;
        }
    }
}

