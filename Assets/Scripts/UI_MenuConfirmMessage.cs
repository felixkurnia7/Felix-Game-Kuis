using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_MenuConfirmMessage : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress;
    [SerializeField]
    private GameObject _pesanCukupKoin;
    [SerializeField]
    private GameObject _pesanTakCukupKoin;
    [SerializeField]
    private TextMeshProUGUI _tempatKoin;

    private UI_OpsiLevelPack _tombolLevelPack;
    private LevelPackKuis _levelPack;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {
        if (!terkunci)
            return;

        gameObject.SetActive(true);

        if (_playerProgress.progressData.koin < levelPack.Harga)
        {
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            return;
        }

        _pesanCukupKoin.SetActive(true);
        _pesanTakCukupKoin.SetActive(false);
        _tombolLevelPack = tombolLevelPack;
        _levelPack = levelPack;
    }

    public void BukaLevel()
    {
        _playerProgress.progressData.koin -= _levelPack.Harga;
        _playerProgress.progressData.progressLevel[_levelPack.name] = 1;

        _tempatKoin.text = $"{_playerProgress.progressData.koin}";
        _playerProgress.SimpanProgress();

        _tombolLevelPack.BukaLevelPack();
    }
}
