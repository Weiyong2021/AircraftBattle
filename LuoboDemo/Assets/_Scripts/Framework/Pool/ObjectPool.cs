using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class ObjectPool:Singleton<ObjectPool>
{
    public string m_ResourcesDir = "";

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();



    //取出对象
    public GameObject Spawn(string name)
    {
        //如果没有该对象的池子，就创建一个新的池子
        if (!m_pools.ContainsKey(name))
            CreateNewPool(name);
        //得到池子
        SubPool pool = m_pools[name];
        //然后调用池子的取得对象的函数，返回一个对象
        return pool.Spawan();

    }

    //回收对象
    public void Unspawn(GameObject go)
    {
        SubPool pool = null;

        foreach(SubPool item in m_pools.Values)
        {
            if(item.Contains(go))
            {
                pool = item;
                break;
            }
        }

        pool.Unspawn(go);//让池子回收该对象。。。
    }

    //回收所有的对象
    public void UnspawanAll()
    {
        foreach (SubPool item in m_pools.Values)
        {
            item.SpawanAll();
        }
    }




    //创建新的子池子
    void CreateNewPool(string name)
    {
        //得到预设体的路径
        string path = "";
        if (string.IsNullOrEmpty(m_ResourcesDir))
            path = name;
        else
            path = m_ResourcesDir + "/" + name;



        //加载预设资源
        GameObject prefab = Resources.Load<GameObject>(path);


        //创建池子
        SubPool pool = new SubPool(prefab);

        //把创建的新的子池子放到容器中。。。。。。。。。。。。
        m_pools.Add(pool.Name, pool);

    }



}
