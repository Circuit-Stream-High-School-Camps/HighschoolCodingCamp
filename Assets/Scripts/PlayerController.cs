using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _bulletPrefab;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private Transform _resetPosition;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private float _movementSpeed = 5, _bulletSpeed, shootSpeed = 0.2f;

    private bool _hasKey = false;
    private float _shootTimer;

    private void Start()
    {
        _gameManager.LivesText.text = "Lives: " + _gameManager.Lives.ToString();
    }

    private void Update()
    {
        Vector2 movementDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementDirection.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementDirection.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementDirection.x = 1;
        }

        _animator.enabled = !movementDirection.Equals(Vector2.zero);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, movementDirection.normalized);
        _rb.velocity = (movementDirection.normalized * _movementSpeed);

        _shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && _shootTimer > shootSpeed)
        {
            _shootTimer = 0;
            var mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            var directionToMouse = mousePos - transform.position;
            var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            bullet.AddForce(directionToMouse.normalized * _bulletSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Key"))
        {
            _hasKey = true;
            Destroy(collider.gameObject);
        }
        else if (collider.CompareTag("Trap"))
        {
            _gameManager.Lives--;
            _gameManager.LivesText.text = "Lives: " + _gameManager.Lives.ToString();
            transform.position = _resetPosition.position;

            if (_gameManager.Lives < 0)
                _gameManager.GameOver();
        }
        else if (collider.CompareTag("WinZone"))
        {
            _gameManager.Win();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;

        if (collider.CompareTag("Lock"))
        {
            if (_hasKey)
            {
                _hasKey = false;
                Destroy(collider.gameObject);
            }
        }
    }
}
