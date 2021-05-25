using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// 这个类是不需要实例化的
/// </summary>

public abstract class ReusableObject : MonoBehaviour, IReusable
{
    //让子类去实现。。。。。。。。。。
    public abstract void OnSpawn();

    public abstract void OnUnSpawn();
}
