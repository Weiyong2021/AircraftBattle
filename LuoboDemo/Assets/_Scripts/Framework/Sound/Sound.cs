using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// 声音管理类
/// </summary>
public class Sound:Singleton<Sound>
{
    //资源路径
    public string ResourceDir = "";

    //播放北景音乐的组件
    private AudioSource m_bgSound;
    //播放音效声音的组件
    private AudioSource m_effectSound;

    protected override void Awake()
    {
        base.Awake();//要保留他

        m_bgSound = this.gameObject.AddComponent<AudioSource>();
        m_bgSound.playOnAwake = false;
        m_bgSound.loop = true;//循环播放


        m_effectSound = this.gameObject.AddComponent<AudioSource>();

    }



    //音乐大小
    public float BgVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value;}
    }

    //音效大小
    public float EffectVolume
    {
        get { return m_effectSound.volume; }
        set { m_effectSound.volume = value; }
    }

    //播放音乐
    public void PlayBg(string audioName)
    {
        //当前正在播放的音乐文件
        string oldName;
        if (m_bgSound.clip == null)
            oldName = "";
        else
            oldName = m_bgSound.clip.name;

        if(oldName!=audioName)
        {
            //音乐文件路径
            string path;
            if(string.IsNullOrEmpty(ResourceDir))
            {
                path = "";
            }
            else
            {
                path = ResourceDir + "/" + audioName;

            }

            //加载音乐音频文件
            AudioClip clip = Resources.Load<AudioClip>(path);
            //播放音乐
            if(clip!=null)
            {
                m_bgSound.clip = clip;
                m_bgSound.Play();

            }
        }
    }


    //停止音乐
    public void StopBg()
    {
        m_bgSound.Stop();
        m_bgSound.clip = null;

    }



    //播放音效
    public void PlayEffect(string audioName)
    {
        //音乐文件路径
        string path;
        if (string.IsNullOrEmpty(ResourceDir))
        {
            path = "";
        }
        else
        {
            path = ResourceDir + "/" + audioName;

        }

        //加载音乐音频文件
        AudioClip clip = Resources.Load<AudioClip>(path);

        m_effectSound.PlayOneShot(clip);
    }



}
