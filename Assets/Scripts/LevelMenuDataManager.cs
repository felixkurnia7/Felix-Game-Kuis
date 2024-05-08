using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress;

    [SerializeField]
    private TextMeshProUGUI _tempatKoin;

    [SerializeField]
    private InisialDataGameplay _inisialData;

    // Start is called before the first frame update
    void Start()
    {
        _tempatKoin.text = $"{_playerProgress.progressData.koin}";
    }

    private void OnApplicationQuit()
    {
        _inisialData.SaatKalah = false;
    }
}
