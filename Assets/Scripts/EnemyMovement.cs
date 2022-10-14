using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float[] _wayPointsX = new float[2];

    private const string IsRunName = "isRun";

    private Animator _animator;
    private SpriteRenderer _sprite;
    private bool _isAlive = true;
    private int _isRunHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _isRunHash = Animator.StringToHash(IsRunName);
    }

    private void Start()
    {
        StartCoroutine(Walk());
    }

    private IEnumerator Walk()
    {
        float waitSeconds = 1f;
        WaitForSeconds waitTime = new WaitForSeconds(waitSeconds);
        int index = 0;

        while (_isAlive)
        {
            index = ++index % 2;
            _sprite.flipX = index == 0;
            yield return WalkToPoint(_wayPointsX[index]);
            yield return waitTime;
        }
    }

    private IEnumerator WalkToPoint(float target)
    {
        _animator.SetBool(_isRunHash, true);

        while (transform.position.x != target)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, target, _speed * Time.deltaTime), transform.position.y, transform.position.z);
            yield return null;
        }

        _animator.SetBool(_isRunHash, false);
    }
}
