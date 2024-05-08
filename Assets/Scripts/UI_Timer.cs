using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public static event System.Action EventWaktuHabis;
    //[SerializeField]
    //private UI_PesanLevel tempatPesan = null;

    [SerializeField]
    private Slider timeBar = null;

    [SerializeField]
    private float waktuJawab = 30f;

    private float sisaWaktu = 0f;
    private bool waktuBerjalan = true;

    public bool WaktuBerjalan
    {
        get => waktuBerjalan;
        set => waktuBerjalan = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        UlangWaktu();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waktuBerjalan)
            return;

        sisaWaktu -= Time.deltaTime;
        timeBar.value = sisaWaktu / waktuJawab;

        if (sisaWaktu <= 0f)
        {
            //tempatPesan.Pesan = "Waktu Sudah Habis!";
            //tempatPesan.gameObject.SetActive(true);
            EventWaktuHabis?.Invoke();
            waktuBerjalan = false;
            return;
        }
    }

    public void UlangWaktu()
    {
        sisaWaktu = waktuJawab;
    }
}
