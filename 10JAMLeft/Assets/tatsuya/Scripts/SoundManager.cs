using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField, Range(0, 1), Tooltip("�}�X�^����")]
    private float volume = 1;
    [SerializeField, Range(0, 1), Tooltip("BGM�̉���")]
    private float bgmVolume = 1;
    [SerializeField, Range(0, 1), Tooltip("SE�̉���")]
    private float seVolume = 1;

    private AudioClip[] bgm;
    private AudioClip[] se;

    private Dictionary<string, int> bgmIndex = new Dictionary<string, int>();
    private Dictionary<string, int> seIndex = new Dictionary<string, int>();

    private AudioSource bgmAudioSource;
    private AudioSource seAudioSource;

    private bool isPlayBGM;

    public bool IsPlayBGM
    {
        get => isPlayBGM;
        set => isPlayBGM = value;
    }

    public float Volume
    {
        set
        {
            volume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return volume;
        }
    }

    public float BgmVolume
    {
        set
        {
            bgmVolume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
        }
        get
        {
            return bgmVolume;
        }
    }

    public float SeVolume
    {
        set
        {
            seVolume = Mathf.Clamp01(value);
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return seVolume;
        }
    }

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource = gameObject.AddComponent<AudioSource>();

        bgm = Resources.LoadAll<AudioClip>("Sound/BGM");
        se = Resources.LoadAll<AudioClip>("Sound/SE");

        for (int i = 0; i < bgm.Length; i++)
        {
            bgmIndex.Add(bgm[i].name, i);
        }
        for (int i = 0; i < se.Length; i++)
        {
            seIndex.Add(se[i].name, i);
        }
    }

    public int GetBgmIndex(string name)
    {
        if (bgmIndex.ContainsKey(name))
        {
            return bgmIndex[name];
        }
        else
        {
            Debug.LogError("�w���BGM�t�@�C���͂���܂���B");
            return 0;
        }
    }

    public int GetSeIndex(string name)
    {
        if (seIndex.ContainsKey(name))
        {
            return seIndex[name];
        }
        else
        {
            Debug.LogError("�w���SE�t�@�C���͂���܂���B");
            return 0;
        }
    }

    /// <summary>
    /// BGM�Đ�
    /// </summary>
    /// <param name="index">�Đ�������BGM�̔ԍ�</param>
    public void PlayBgm(int index)
    {
        index = Mathf.Clamp(index, 0, bgm.Length);

        isPlayBGM = true;
        bgmAudioSource.clip = bgm[index];
        bgmAudioSource.loop = true;
        bgmAudioSource.volume = BgmVolume * Volume;
        bgmAudioSource.Play();
    }

    public void PlayBgmByName(string name)
    {
        PlayBgm(GetBgmIndex(name));
    }

    public void StopBgm()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
        isPlayBGM = false;
    }

    /// <summary>
    /// SE�Đ�
    /// </summary>
    /// <param name="index">�Đ�������SE�̔ԍ�</param>
    public void PlaySe(int index)
    {
        index = Mathf.Clamp(index, 0, se.Length);

        seAudioSource.PlayOneShot(se[index], SeVolume * Volume);
    }

    public void PlaySeByName(string name)
    {
        PlaySe(GetSeIndex(name));
    }

    public void StopSe()
    {
        seAudioSource.Stop();
        seAudioSource.clip = null;
    }
}
