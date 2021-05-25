using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 子对象池
/// </summary>
public class SubPool
{
    //预设资源
    GameObject m_prefab;

    //集合
    List<GameObject> m_objects = new List<GameObject>();

    //名字
    public string Name
    {
        get { return m_prefab.name; }
    }

    public SubPool(GameObject prefab)
    {
        this.m_prefab = prefab;
    }

    //取出对象
    public GameObject Spawan()
    {
        GameObject obj = null;
        foreach (GameObject go in m_objects)
        {
            if(!go.activeSelf)
            {
                obj = go;
                break;
            }
        }
        if(obj==null)
        {
            obj = GameObject.Instantiate<GameObject>(m_prefab);
            m_objects.Add(obj);
        }

        obj.SetActive(true);
        //发送信息说    初始化对象
        obj.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

        return obj;
    }

    //回收对象

    public void Unspawn(GameObject go)
    {
        if(Contains(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);

        }
    }


    //是否包含对象
    public bool Contains(GameObject go)
    {
        return m_objects.Contains(go);
    }


    //回收该池子的所有对象
    public void SpawanAll()
    {
        foreach (GameObject  item in m_objects)
        {
            if(item.activeSelf)
            {
                Unspawn(item);

            }
        }
    }

}
