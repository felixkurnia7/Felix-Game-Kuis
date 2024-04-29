using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_PesanLevel : MonoBehaviour
{
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
