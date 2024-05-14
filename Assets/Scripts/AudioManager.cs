using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource _bgmPrefab;

    [SerializeField]
    private AudioSource _sfxPrefab;

    [SerializeField]
    private AudioClip[] _bgmClips;

    private AudioSource _bgm;
    private AudioSource _sfx;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            _bgm = Instantiate(_bgmPrefab);
            DontDestroyOnLoad(_bgm);

            _sfx = Instantiate(_sfxPrefab);
            DontDestroyOnLoad(_sfx);
        }
        
    }

    private void OnDestroy()
    {
        if (this == instance)
        {
            instance = null;
            if (_bgm != null)
                Destroy(_bgm.gameObject);
            if (_sfx != null)
                Destroy(_sfx.gameObject);
        }
    }

    public void PlayBGM(int index)
    {
        if (_bgm.clip == _bgmClips[index])
            return;

        _bgm.clip = _bgmClips[index];
        _bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfx.PlayOneShot(clip);
    }
}
