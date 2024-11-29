using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCreditButton : MonoBehaviour
{
    [SerializeField] GameObject titleOptionPanel;

    public void OnClick()
    {
        titleOptionPanel.SetActive(false);
    }
}
