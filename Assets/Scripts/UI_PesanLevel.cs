using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_PesanLevel : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject opsiMenang;

    [SerializeField]
    private GameObject opsiKalah;

    [SerializeField]
    private TextMeshProUGUI tempatPesan = null;

    public string Pesan
    {
        get => tempatPesan.text;
        set => tempatPesan.text = value;
    }

    private void Awake()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);

        UI_Timer.EventWaktuHabis += UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        UI_Timer.EventWaktuHabis -= UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void UI_Timer_EventWaktuHabis()
    {
        Pesan = "Waktu Sudah Habis!";
        gameObject.SetActive(true);

        opsiMenang.SetActive(false);
        opsiKalah.SetActive(true);

        _animator.SetBool("Menang", false);
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawabanTeks, bool adalahBenar)
    {
        Pesan = $"Jawaban Anda {adalahBenar} (Jawab: {jawabanTeks})";
        gameObject.SetActive(true);

        if (adalahBenar)
        {
            opsiMenang.SetActive(true);
            opsiKalah.SetActive(false);
        }
        else
        {
            opsiMenang.SetActive(false);
            opsiKalah.SetActive(true);
        }

        _animator.SetBool("Menang", adalahBenar);
    }
}
