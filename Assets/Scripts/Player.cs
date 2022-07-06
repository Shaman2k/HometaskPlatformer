using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _coins;

    public event UnityAction<int> CoinCollected;
    public event UnityAction Died;
    public event UnityAction LevelComleted;

    public int Coins => _coins;

    public void Die()
    {
        Died?.Invoke();
    }

    public void CollectCoin()
    {
        _coins++;
        CoinCollected?.Invoke(_coins);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            CollectCoin();
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent<FinishPoint>(out FinishPoint point))
        {
            LevelComleted?.Invoke();
        }
    }
}
