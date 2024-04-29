using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public struct DataSoal
    {
        public string pertanyaan;
        public Sprite petunjukJawaban;

        public string[] pilihanJawaban;
        public bool[] adalahBenar;
    }

    [SerializeField]
    private DataSoal[] soalSoal = new DataSoal[0];

    [SerializeField]
    private UI_Pertanyaan _pertanyaan = null;

    [SerializeField]
    private UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];

    private int _indexSoal = -1;

    // Start is called before the first frame update
    void Start()
    {
        NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        _indexSoal++;

        if (_indexSoal >= soalSoal.Length)
        {
            _indexSoal = 0;
        }

        DataSoal soal = soalSoal[_indexSoal];

        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", soal.pertanyaan, soal.petunjukJawaban);

        for (int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            poin.SetJawaban(soal.pilihanJawaban[i], soal.adalahBenar[i]);
        }
    }
}
