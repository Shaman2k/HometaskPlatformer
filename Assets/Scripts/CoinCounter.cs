using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _coins;

    private void Awake()
    {
        _coins = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _player.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected(int count)
    {
        _coins.text = count.ToString();
    }
}
