using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _count;

    public int Count { get { return _count; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Collector>(out Collector collector))
        {
            Destroy(gameObject);
        }
    }
}
