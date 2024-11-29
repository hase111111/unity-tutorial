using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawnButton : MonoBehaviour
{
    [SerializeField] int _index;
    Button _button;
    MoneyCounter _moneyCounter;
    int _cost;

    void Start()
    {
        _button = GetComponent<Button>();

        var playerCharacterSpawner = FindObjectOfType<PlayerCharacterSpawner>();
        if (playerCharacterSpawner == null)
        {
            Debug.LogError("PlayerCharacterSpawner not found");
            return;
        }

        _button.onClick.AddListener(() =>
               {
                   playerCharacterSpawner.SpawnPlayer(_index);
               });

        _cost = playerCharacterSpawner._playerMoney[_index];
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // ‚¨‹à‚ª‘«‚è‚Ä‚¢‚é‚©‚Ç‚¤‚©‚Åƒ{ƒ^ƒ“‚Ì—LŒø–³Œø‚ðØ‚è‘Ö‚¦‚é
        _button.interactable = _moneyCounter.Money >= _cost;
    }
}
