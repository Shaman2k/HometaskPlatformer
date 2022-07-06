using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 2f;

    private Vector3 _position;
    private float _cameraPositionZ = -10f;
    private float _cameraOffsetY = 3f;
    private float _cameraOffsetX = 6f;
    
    private void Update()
    {
        _position = _player.transform.position;
        _position.z = _cameraPositionZ;
        _position.y += _cameraOffsetY;
        _position.x += _cameraOffsetX;
        transform.position = Vector3.Lerp(transform.position, _position, _speed * Time.deltaTime);
    }
}
