using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine.SceneManagement;

public class sqlstats 
{

    private static sqlstats _instance;

    //注册界面
  

    private InputField regisUsername;
    private InputField repassword;
    private Dropdown resexy;
    private InputField reage;

    private bool isgameover;

   
   
    
    //登入界面
    
    private InputField UsernameInput;
    private InputField Password;
   private Text hinttext ;//提示文本
   private Text hinttext1 ;//提示文本
    private string Password1;
    private string  username;
   
   
    List<string> Usenamelist = new List<string>();
    public static sqlstats Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new sqlstats();
                
            }
            return _instance;
        }
    }

   

    // public Action<string,Action<string>> text1;//委托到Accout里传递表达的Text
    public Action<string,bool >text1;
    public Action<string> text2;
    private void Start()
    {
       

    }
    private sqlstats(){}

    public void regions(string[] str)
    {
        //将读取数据库的账号密码存入字典里面
        Dictionary<string, string> myDic = new Dictionary<string, string>();
        
        
        myDic.Clear();
        //连接数据库
        string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=scyscy111;Charset=utf8";
        //定义数据库连接对象，传递对象
     MySqlConnection conn = new MySqlConnection(connectStr); //并没有建立数据库连接
        //打开数据库
        conn.Open();
        //数据库连接成功
        Debug.Log("数据库" + "mygamedb" + "连接成功");

//执行Mysql语句并读取结果
        MySqlCommand myCommand = new MySqlCommand("select*from users", conn);
        MySqlDataReader reader = myCommand.ExecuteReader();
        //读取具体数据
        while (reader.Read())
        {
            string username = reader.GetString("username");
            string Password1 = reader.GetString("password");
          
           
            myDic.Add(username,Password1);
          
        }

        if (myDic.ContainsKey(str[0]))
        {
            text2.Invoke("账号存在！请重新注册");
            
        }
        else
        {
            reader.Close();
            string strinsert="insert into users (username,password,age,sexy)values('"+str[0].ToString()+"','"+str[1].ToString()+"','"+str[2].ToString()+"','"+str[3].ToString()+"')";
            MySqlCommand cmd = new MySqlCommand(strinsert, conn);
            cmd.ExecuteNonQuery();
            text2.Invoke("注册成功！");
            conn.Close();
            
        }
    }
   //登录界面方法
    public void Login(string[] str)
    {
        
        //将读取数据库的账号密码存入字典里面
        Dictionary<string, string> myDic = new Dictionary<string, string>();
        myDic.Clear();
        //连接数据库
        string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=scyscy111;";
        //定义数据库连接对象，传递对象
        MySqlConnection conn = new MySqlConnection(connectStr); //并没有建立数据库连接
        //打开数据库
        conn.Open();
       //数据库连接成功
        Debug.Log("数据库" + "mygamedb" + "连接成功");

//执行Mysql语句并读取结果
        MySqlCommand myCommand = new MySqlCommand("select*from users", conn);
        MySqlDataReader reader = myCommand.ExecuteReader();

      
        //读取具体数据
        while (reader.Read())
        {
            string username = reader.GetString("username");
            string Password1 = reader.GetString("password");
            
           myDic.Add(username,Password1);
           
        }
       
        if (myDic.ContainsKey(str[0]))
        {
            PlayerPrefs.SetString("CurrentName",str[0]); 
            string vale;
            if (myDic.TryGetValue(str[0], out vale))
            {   
                if (vale==str[1])
                {
                  Usenamelist.Add(username);
               
                    
                  text1.Invoke ("登入成功！",true) ;
                  
                }
                else
                { 
                   
                    //最好可以写一个清空账号的功能
                    text1.Invoke("密码错误请重新输入", false);

                }
            }
        }
        else
        {
        
          text1.Invoke("账号不存在！请注册", false);
        }
        //关闭读取和连接数据库
        reader.Close();
        conn.Close();
      
    }

    
    public Action<string, string, int, string> mangerss;
    public void readdate()
    { 
        Debug.Log("3");

        

        string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=scyscy111;";
        //定义数据库连接对象，传递对象
        MySqlConnection conn = new MySqlConnection(connectStr); //并没有建立数据库连接
        //打开数据库
        conn.Open();
        //数据库连接成功
        Debug.Log("数据库" + "mygamedb" + "连接成功");
        
//执行Mysql语句并读取结果
        MySqlCommand myCommand = new MySqlCommand("select * from users where  1='1'", conn);
        MySqlDataReader reader=myCommand.ExecuteReader();
        
        // MySqlDataReader reader = select2("users", new[] {"*"}, new[] {"1"}, new string[] {"="}, new string[] {"1"});
        while (reader.Read())
        {     
           string lever = reader.GetString("leve");
           string name = reader.GetString("username");
           int age = reader.GetInt32("age");
           string sexy= reader.GetString("sexy");
           if(name.Equals(PlayerPrefs.GetString("CurrentName")))
           {
               PlayerPrefs.SetString("CurrentSex",sexy);
               PlayerPrefs.SetInt("Currentage",age);
               PlayerPrefs.SetString("Currentlever",lever);
           }

           mangerss.Invoke(PlayerPrefs.GetString("CurrentName"),PlayerPrefs.GetString("CurrentSex"),PlayerPrefs.GetInt("Currentage"),PlayerPrefs.GetString("Currentlever"));
break;
        }
        
        
        
        
    }

 
//老师方法
    public MySqlDataReader select2(string tableName, string[] itms, string[] wherecolname, string[] operation,
        string[] vale)
    {
        if (wherecolname.Length != operation.Length || operation.Length != vale.Length)
        {
            throw new Exception("buzq");
        }
    
        string Query = "SELECT" + itms[0];
        for(int i=1;i<itms.Length;i++)
        {
            Query += "," + itms[i];
        }
    
        Query += "FROM" + tableName + "WHERE" + "" + wherecolname[0] + operation[0] + "'" + vale[0] + "'";
        for(int i=1;i<wherecolname.Length;i++)
        {
            Query += "AND" + wherecolname[i] + operation[i] + "'" + vale[i] + "'";
        }
        Debug.Log(Query);
        return queryset2(Query);
    }
    
    public static MySqlConnection mySqlConnection;
    public static MySqlDataReader queryset2(string sqlstring)
    {
        if (mySqlConnection.State == ConnectionState.Open)
        {
            MySqlCommand com = new MySqlCommand(sqlstring, mySqlConnection);
            MySqlDataReader read = com.ExecuteReader();
            return read;
        }
    
        return null;
    }
    void Update()
    {
        
    }
    
    
}
