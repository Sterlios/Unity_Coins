using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Count { get { return _count; } }

    [SerializeField] private int _count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Collector>(out Collector collector))
        {
            Destroy(gameObject);
        }
    }
}
