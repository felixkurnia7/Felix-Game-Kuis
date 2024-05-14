using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _inisialData;

    [SerializeField]
    private PlayerProgress _playerProgress;

    [SerializeField]
    private UI_OpsiLevelKuis _tombolLevel;

    [SerializeField]
    private RectTransform _content;

    [Space, SerializeField]
    private LevelPackKuis _levelPack;

    [SerializeField]
    private GameSceneManager _gameSceneManager;

    [SerializeField]
    private string _gameplayScene;

    private void Start()
    {
        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        _inisialData.levelIndex = index;
        _gameSceneManager.BukaScene(_gameplayScene);
    }

    public void UnloadLevelPack(LevelPackKuis levelPack)
    {
        HapusIsiKonten();

        var levelTerbukaTerakhir = _playerProgress.progressData.progressLevel[levelPack.name] - 1;

        _levelPack = levelPack;
        for (int i = 0; i < levelPack.banyakLevel; i++)
        {
            var t = Instantiate(_tombolLevel);

            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            if (i > levelTerbukaTerakhir)
            {
                t.InteraksiTombol = false;
            }
        }
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for (int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
