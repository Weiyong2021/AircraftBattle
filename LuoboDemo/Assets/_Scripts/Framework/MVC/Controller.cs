using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// 控制器是无状态的，不用实例化，和事件有关
//只需要类型    一个控制器对应一个事件，当一个事件触发的
//时候，就动态创建一个控制器去处理派发的消息。。。。。。。。
public abstract class Controller
{

    //获取模型
    protected Model GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>();

    }

    //获取视图
    protected View GetView<T>() where T : View
    {
        return MVC.GetView<T>();

    }


    //处理系统消息
    public abstract void Execute(object data);



    //在某些情况下   可能还要注册模型和视图 和控制器类型

    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);

    }


    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);

    }

    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);

    }

}
