using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tempatJudul;

    [SerializeField]
    private TextMeshProUGUI tempatTeks;
    
    [SerializeField]
    private Image tempatGambar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Isi tempat teks yaitu " + tempatTeks.text);
    }

    public void SetPertanyaan(string judul, string teksPertanyaan, Sprite gambarHint)
    {
        tempatJudul.text = judul;
        tempatTeks.text = teksPertanyaan;
        tempatGambar.sprite = gambarHint;
    }
}
