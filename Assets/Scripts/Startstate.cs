using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

//委托，代理模式//观察者
public class Startstate : ISceneState
{  public Startstate(SceneContorl sceneContorl) : base("Start", sceneContorl) { }

    private Transform mUIRoot;
    //开始页面
    private Transform  startbg;
    private Transform registerbg;
    private Transform singbg;
    private Text hinttext;
    private Text hinttext1;
  
    public override void StateStart()
    {//传递参数告诉登入成功
        sqlstats.Instance.text1 = (e,t) =>
        {
            hinttext.text = e;
            
            
           if(t)
            {
                mController.Setstate(new LoadState(mController));
               
            }
            else
            {
                Debug.Log("密码错误");
            }
        };//执行委托事件
          sqlstats.Instance.text2 = (e) =>
        {
            hinttext1.text = e;
        };//执行委托事件
         
        Init();
        MyOnEnable();
        
        // hinttext =  GameObject.FindWithTag("hint").GetComponent<Text>();
        UsernameInput = singbg.transform.Find("loginbg/ACCount/UsernameInput").GetComponent<InputField>();
        Password = singbg.transform.Find("loginbg/Password/PasswordInput").GetComponent<InputField>();
        regisUsername = registerbg.transform.Find("loginbg/ACCount/UsernameInput").GetComponent<InputField>();
        repassword= registerbg.transform.Find("loginbg/Password/PasswordInput").GetComponent<InputField>();
        resexy = registerbg.transform.Find("loginbg/sexy/sexyDropdown").GetComponent<Dropdown>();
        reage = registerbg.transform.Find("loginbg/age/ageInput").GetComponent<InputField>();
    }

    private void Init()
    {
        mUIRoot = GameObject.Find("Canvas").transform;
        registerbg=mUIRoot.Find("Register");
            singbg =mUIRoot.Find("SignBG"); 
        startbg=mUIRoot.Find("StartBG");
        hinttext=singbg.GetChild(3).GetComponent<Text>();
        hinttext1=registerbg.GetChild(3).GetComponent<Text>();
        
    }


    //注册界面
    

    private InputField regisUsername;
    private InputField repassword;
    private Dropdown resexy;
    private InputField reage;
    
   
    //登入界面
 
    private InputField UsernameInput;
    private InputField Password;
//提示文本
    private string Password1;
    private string  username;
    private string Age;
    private string sexy;
   

   
    
    void Start()
    {
        
        // sqlstats.Instance.text1 = (e, r) =>
        // {
        //     hinttext.text = e;
        //     r.Invoke(gameObject.name);
        // };//回调参数的委托，获取到事件
        
    }
    //注册界面方法
   
    private void emptytex()
    {
        regisUsername.text = "";
        repassword.text = "";
        UsernameInput.text = "";
        Password.text = "";
        hinttext.text = "";
       
    }
    private void MyOnEnable()
    {
        //开始界面功能实现
        List<Button> loainWindowButtonList = new List<Button>();
        loainWindowButtonList.AddRange(startbg.GetComponentsInChildren<Button>());//添加整个列表元素到列表里面
        foreach (Button button in loainWindowButtonList)
        {
            button.onClick.AddListener(() =>
            {
                LoginWindowButtonClick(button);

            });
        }
        //登入界面的代码实现
        List<Button> signButtonList = new List<Button>();//创建一个按钮的数列
        signButtonList.AddRange(singbg.GetComponentsInChildren<Button>());
        foreach (Button  button1 in signButtonList)
        {
            button1.onClick.AddListener(() =>
            {
                LoginWindowButtonClick(button1);
            });
        }

        List<Button> reButtonList = new List<Button>();
        reButtonList.AddRange(registerbg.GetComponentsInChildren<Button>());
        foreach (Button  button2 in reButtonList)
        {
            button2.onClick.AddListener(() =>
            {
                LoginWindowButtonClick(button2);
            });
        }

    }
    //模式管理场景的按钮
   
        private void LoginWindowButtonClick(Button sender)
          {
  
        switch (sender.name)
        {
            case "Startgame":

                {
                    Debug.Log("进入游戏");
                    startbg.gameObject.SetActive(false);
                    singbg.gameObject.SetActive(true);
                    emptytex();
                }
                break;

            case "exit":
                {
#if UNITY_EDITOR //编辑器中退出游戏
                    UnityEditor.EditorApplication.isPlaying = false;

                    UnityEngine.Application.Quit();
#endif

                }
                break;
            case "Back":
                {
                    Debug.Log("返回主菜单");
                    singbg.gameObject.SetActive(false);
                    startbg.gameObject.SetActive(true);
                    emptytex();

                }
                break;
            
            //注册界面注册按钮
            case "Rebutton":
            {
                
                Debug.Log("ok");
                username = regisUsername.text.Trim();
                Password1 = repassword.text.Trim();
                Age = reage.text.Trim();
                sexy = resexy.captionText.text;
                if (username == ""||Password1=="")
                    
                {
                    hinttext1.text="用户的账号密码不能为空";
                    
                   
                }
                else
                {
                   sqlstats.Instance.regions(new string[] {username, Password1,Age,sexy});
                }
            } break;
            case "Back1":
            {
                
                singbg.gameObject.SetActive(true);
               registerbg.gameObject.SetActive(false);
               emptytex();
            }
                break;
            //登入界面登入按钮
            case "siginbutton":
            {
                singbg.gameObject.SetActive(false);
                registerbg.gameObject.SetActive(true);
            }break;
            case "logbutten":
            {
                Debug.Log("成功");
                username = UsernameInput.text.Trim();
               Password1 = Password.text.Trim();
                if (UsernameInput.text.Trim() == ""||Password.text.Trim()=="")
                    
                {
                     hinttext.text="用户的账号密码不能为空，请输入";
                    // inttt("用户的账号密码不能为空，请注册");
                    // sqlstats.Instance.hinttext.text = "用户账号密码不能为空请注册";
                }
                else 
                {
                    //Login(new string[] { username, Password1 });
                   sqlstats.Instance.Login(new []{username, Password1});
                }
                
            }
           break;
            default:
                break;
        }
    }


}
