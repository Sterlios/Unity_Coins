using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            IsGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            IsGround = false;
        }
    }
}
