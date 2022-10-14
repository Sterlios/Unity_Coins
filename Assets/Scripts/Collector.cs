using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet += coin.Count;
        }
    }
}
