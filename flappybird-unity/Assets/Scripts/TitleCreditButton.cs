using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCreditButton : MonoBehaviour
{
    [SerializeField] GameObject _creditPanel;
    [SerializeField] GameObject _rankingPanel;

    public void OnClickCloseButton()
    {
        _creditPanel.SetActive(true);
    }

    public void OnClickRankingButton()
    {
        _rankingPanel.SetActive(true);
    }
}
