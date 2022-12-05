using Unity.Collections;
using UnityEngine;
using UnityEngine.Audio;

/// <summar
/// 音效管理
/// </summary>
public class GlobalAudioManager : MonoBehaviour
{
    private static GlobalAudioManager instance;
    public static GlobalAudioManager Instance() => instance;
    [Header("背景音乐与音效的混合器")]
    public AudioMixer Mixer;
    [Header("当前正在播放的BGM")]
    [SerializeField] [ReadOnly] private AudioSource playing_BGM;

    [Header("Testing")] 
    [SerializeField] [Range(-80f, 20f)] private float master_volume = -10;
    [SerializeField] [Range(-80f, 20f)] private float bgm_volume = -10;
    [SerializeField] [Range(-80f, 20f)] private float eff_volume = -10;

    private void Awake()
    {
        if (instance != null) Debug.LogError($"{GetType().Name} instance already exsit.");
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
       
    }
    // 这里做测试用，我就放到update中实时更新，正式使用可以在设置的UI面板中的音量的滑动条改动时再设置就好了
    private void Update()
    {
        SetMASTER_Volume(master_volume);
        SetBGM_Volume(bgm_volume);
        SetEFF_Volume(eff_volume);
    }
    // 重播BGM
    public void RestartBGM()
    {
        if (playing_BGM != null)
        {
            playing_BGM.time = 0;
        }
    }
    // 播放BGM
    public void PlayBGM(AudioSource bgm)
    {
        if (playing_BGM != null) playing_BGM.Stop();
        playing_BGM = bgm;
        playing_BGM.outputAudioMixerGroup = Mixer.FindMatchingGroups("BGM")[0];
        playing_BGM.Play();
    }
    // 播放EFF
    public void PlayEff(AudioSource eff)
    {
        eff.outputAudioMixerGroup = Mixer.FindMatchingGroups("EFF")[0];
        eff.Play();
    }
    // 获取MASTER音量
    public float GetMASTER_Volume()
    {
        Mixer.GetFloat("MASTER_Volume", out float value);
        return value;
    }
    // 设置MASTER音量
    public void SetMASTER_Volume(float value)
    {
        Mixer.SetFloat("MASTER_Volume", Mathf.Clamp(value, -80, 20));
    }
    // 获取BGM音量
    public float GetBGM_Volume()
    {
        Mixer.GetFloat("BGM_Volume", out float value);
        return value;
    }
    // 设置BGM音量
    public void SetBGM_Volume(float value)
    {
        Mixer.SetFloat("BGM_Volume", Mathf.Clamp(value, -80, 20));
    }
    // 获取EFF音量
    public float GetEFF_Volume()
    {
        Mixer.GetFloat("EFF_Volume", out float value);
        return value;
    }
    // 设置EFF音量
    public void SetEFF_Volume(float value)
    {
        Mixer.SetFloat("EFF_Volume", Mathf.Clamp(value, -80, 20));
    }
}

