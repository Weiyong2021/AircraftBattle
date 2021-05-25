using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class Model
{
    public abstract string Name
    {
        get;
    }

    protected void SendEvent(string eventName,object data=null)
    {
        //委托第三方MVC去发送的
        MVC.SendEvent(eventName, data);
    }

}
