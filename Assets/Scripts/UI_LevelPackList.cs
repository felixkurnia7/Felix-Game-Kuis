using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private UI_LevelKuisList _levelList;

    [SerializeField]
    private UI_OpsiLevelPack _tombolLevelPack;

    [SerializeField]
    private RectTransform _content;

    [SerializeField]
    private InisialDataGameplay _inisialData;


    private void Start()
    {
        //LoadLevelPack();

        if (_inisialData.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(null, _inisialData.levelPack, false);
        }

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {
        if (terkunci)
            return;

        //_levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);

        //gameObject.SetActive(false);

        _inisialData.levelPack = levelPack;
        _animator.SetTrigger("KeLevel");
    }

    public void LoadLevelPack(LevelPackKuis[] levelPacks, PlayerProgress.MainData playerData)
    {
        foreach (var lp in levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            t.transform.SetParent(_content);

            t.transform.localScale = Vector3.one;

            if (!playerData.progressLevel.ContainsKey(lp.name))
            {
                t.KunciLevelPack();
            }
        }
    }
}
