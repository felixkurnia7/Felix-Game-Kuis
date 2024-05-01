using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private LevelPackKuis soalSoal = null;

    [SerializeField]
    private UI_Pertanyaan _pertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];

    private int _indexSoal = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (!_playerProgress.MuatProgress())
            _playerProgress.SimpanProgress();

        NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        _indexSoal++;

        if (_indexSoal >= soalSoal.banyakLevel)
        {
            _indexSoal = 0;
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
