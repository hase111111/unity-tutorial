using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingCloseButton : MonoBehaviour
{
    [SerializeField] GameObject _creditPanel;

    public void OnClickCloseButton()
    {
        _creditPanel.SetActive(false);
    }
}
