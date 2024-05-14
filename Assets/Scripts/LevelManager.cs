using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _inisialData;

    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private LevelPackKuis soalSoal = null;

    [SerializeField]
    private UI_Pertanyaan _pertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];

    [SerializeField]
    private GameSceneManager _gameSceneManager;

    [SerializeField]
    private string _namaScenePilihMenu;

    [SerializeField]
    private PemanggilSuara _pemanggilSuara;

    [SerializeField]
    private AudioClip _sfxMenang;

    [SerializeField]
    private AudioClip _sfxKalah;

    private int _indexSoal = -1;

    // Start is called before the first frame update
    void Start()
    {
        soalSoal = _inisialData.levelPack;
        _indexSoal = _inisialData.levelIndex - 1;

        NextLevel();
        AudioManager.instance.PlayBGM(1);

        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void OnApplicationQuit()
    {
        _inisialData.SaatKalah = false;
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        _pemanggilSuara.PanggilSuara(adalahBenar ? _sfxMenang : _sfxKalah);

        if (!adalahBenar)
            return;

        var namaLevelPack = _inisialData.levelPack.name;
        int levelTerakhir = _playerProgress.progressData.progressLevel[namaLevelPack];

        if (_indexSoal + 2 > levelTerakhir)
        {
            _playerProgress.progressData.koin += 20;
            _playerProgress.progressData.progressLevel[namaLevelPack] = _indexSoal + 2;
            _playerProgress.SimpanProgress();
        }
    }

    public void NextLevel()
    {
        _indexSoal++;

        if (_indexSoal >= soalSoal.banyakLevel)
        {
            //_indexSoal = 0;
            _gameSceneManager.BukaScene(_namaScenePilihMenu);
            return;
        }

        LevelSoalKuis soal = soalSoal.AmbilLevelKe(_indexSoal);

        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", soal.pertanyaan, soal.petunjukJawaban);

        for (int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawaban, opsi.adalahBenar);
        }
    }
}
