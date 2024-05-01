using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Soal Baru",
    menuName = "Game Kuis/Level Soal Kuis")]
public class LevelSoalKuis : ScriptableObject
{
    [System.Serializable]
    public struct OpsiJawaban
    {
        public string jawaban;
        public bool adalahBenar;
    }

    public string pertanyaan = null;
    public Sprite petunjukJawaban = null;

    public OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];
}
