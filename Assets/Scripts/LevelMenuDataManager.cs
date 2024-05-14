using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private UI_LevelPackList _levelPackList;

    [SerializeField]
    private PlayerProgress _playerProgress;

    [SerializeField]
    private TextMeshProUGUI _tempatKoin;

    [SerializeField]
    private InisialDataGameplay _inisialData;

    [Space, SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    // Start is called before the first frame update
    void Start()
    {

        if (!_playerProgress.MuatProgress())
            _playerProgress.SimpanProgress();

        _levelPackList.LoadLevelPack(_levelPacks, _playerProgress.progressData);

        _tempatKoin.text = $"{_playerProgress.progressData.koin}";
        AudioManager.instance.PlayBGM(0);
    }

    private void OnApplicationQuit()
    {
        _inisialData.SaatKalah = false;
    }
}
