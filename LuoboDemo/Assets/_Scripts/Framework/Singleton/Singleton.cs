using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 继承于MonoBehaviour 的单例模式模板
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance = null;
    public static T Instance => instance;

    protected virtual void Awake()    //搞成虚方法，让子类可以重写他
    {
        instance = this as T;

    }

}
