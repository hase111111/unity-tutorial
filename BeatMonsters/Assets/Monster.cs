using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _healthLabel;
    [SerializeField] Image _monsterImage;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Player _player;
    [SerializeField] GameObject _coinParticle;
    [SerializeField] GameObject _attackParticle;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _coinClip;

    readonly EntityLevelUp _entityLevelUp = new EntityLevelUp();
    int _health = 10;
    int _maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickMonster()
    {
        _health -= _player.GetPower();
        _healthLabel.text = $"{_health} / {_maxHealth}";

        var position = transform.position;
        position += new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f);
        var attack_effect = Instantiate(_attackParticle, position, Quaternion.identity);
        Destroy(attack_effect, 0.5f);

        if (_health <= 0)
        {
            Setup();

            _player.OnKillMonster();

            var coin_effect = Instantiate(_coinParticle, transform.position, Quaternion.identity);
            Destroy(coin_effect, 1.0f);

            _audioSource.PlayOneShot(_coinClip);
        }
    }

    void Setup()
    {
        int kill_count = (_player != null) ? _player.KillCount : 1;
        _maxHealth = _entityLevelUp.GetMonsterHealth(kill_count);
        _player.KillCount += 1;

        _health = _maxHealth;
        _healthLabel.text = $"{_health} / {_maxHealth}";

        int image_index = Random.Range(0, _sprites.Length);
        _monsterImage.sprite = _sprites[image_index];
    }
}
