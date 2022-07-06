using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _patrolRoute;
    [SerializeField] private float _speed;

    private SpriteRenderer _renderer;
    private Transform[] _points;
    private int _currentPoint;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_patrolRoute.transform.childCount];

        for (int i = 0; i < _patrolRoute.transform.childCount; i++)
        {
            _points[i] = _patrolRoute.transform.GetChild(i);
        }

        _currentPoint = 0;
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
        _renderer.flipX = direction.x > 0 ? true : false;

        if (transform.position.x == target.position.x)
            SetCurrentPoint();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Player>(out Player player))
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y <= -0.6f)
                    Destroy(gameObject);
                else
                    player.Die();
            }
        }
    }

    private void SetCurrentPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Length)
            _currentPoint = 0;
    }
}
