using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 可以把它看做一个系统   第三方代表者   或者中间商
/// </summary>
public static class MVC
{
    //存储MVC
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();//名字----模型
    public static Dictionary<string, View> Views = new Dictionary<string, View>();//名字------视图
    public static Dictionary<string, Type> commanMap = new Dictionary<string, Type>();//事件名字-----控制器类型

    //注册
    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;

    }

    public static void RegisterView(View view)
    {
        Views[view.Name] = view;

    }

    public static void RegisterController(string eventName,Type conrollerType)
    {
        commanMap[eventName] = conrollerType;

    
    }

    //获取模型
    public static Model GetModel<T>() where T:Model
    {
        foreach (Model item in Models.Values)
        {
            if(item is T)
            {
                return item;
            }
        }
        return null;

    }

    //获取试图
    public static View GetView<T>() where T:View
    {
        foreach (View item in Views.Values)
        {
            if (item is T)
            {
                return item;
            }
        }
        return null;
    }


    //发送事件

    public static void SendEvent(string eventName,object data=null)
    {
        //优先相应控制器事件
        if(commanMap.ContainsKey(eventName))
        {
            //因为事件名字和控制器类型是一一对应的
            //根据事件名字得到控制器类型
            Type t = commanMap[eventName];
            //根据控制器类型利用反射原理创建控制器对象
            Controller c = Activator.CreateInstance(t) as Controller;
            //让控制器去处理事件。。。
            c.Execute(data);

        }


        //视图相应事件
        foreach(View v in Views.Values)
        {
            if(v.AttionEvent.Contains(eventName))
            {
                //视图相应事件
                v.HandleEvent(eventName, data);

            }
        }

    }

}
