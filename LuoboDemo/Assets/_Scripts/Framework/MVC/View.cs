using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// 视图都必须继承Mono
/// </summary>
public abstract class View:MonoBehaviour
{
    //试图的标识
    public abstract string Name
    {
        get;
    }

    //关心的事件列表
    public List<string> AttionEvent = new List<string>();

    //事件处理的函数
    public abstract void HandleEvent(string eventName, object data);

    //获取模型
    protected Model GetModel<T>() where T:Model
    {
        return MVC.GetModel<T>();

    }




    //发送消息    //给控制层发送的
    protected void SendEvent(string eventName,object data=null)
    {
        MVC.SendEvent(eventName, data);

    }


}
