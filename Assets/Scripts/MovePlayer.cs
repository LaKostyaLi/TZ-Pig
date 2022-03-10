using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{  
    [SerializeField] GameObject _up=null;
    [SerializeField] GameObject _down=null;
    [SerializeField] GameObject _left = null;
    [SerializeField] GameObject _right = null;

    [SerializeField] GameObject _player;

    [SerializeField] GameObject _bomb;
   
    public float _speed = 1;

    private float HorizontalSpeed;
    private float VerticalSpeed;

    Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.Translate(HorizontalSpeed, 0, 0);
        transform.Translate(0, VerticalSpeed, 0);
    }

    public void OnRight()
    {
        HorizontalSpeed = _speed;

        _up.SetActive(false);
        _down.SetActive(false);
        _right.SetActive(true);
        _left.SetActive(false);
    }

    public void OnLeft()
    {
        HorizontalSpeed = -_speed;

        _up.SetActive(false);
        _down.SetActive(false);
        _right.SetActive(false);
        _left.SetActive(true);
    }

    public void OnUp()
    {
        VerticalSpeed = _speed;

        _up.SetActive(true);
        _down.SetActive(false);
        _right.SetActive(false);
        _left.SetActive(false);
    }

    public void OnDown()
    {
        VerticalSpeed = -_speed;

        _up.SetActive(false);
        _down.SetActive(true);
        _right.SetActive(false);
        _left.SetActive(false);
    }

    public void Stop()
    {
        VerticalSpeed = 0;
        HorizontalSpeed = 0;
    }

    public void Bomb()
    {
        GameObject bomb = Instantiate(_bomb, _player.transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (_player.transform.position.y > 3.7f)
        {
            _player.transform.position = new Vector2(_player.transform.position.x, 3.66f);
        }
        if (_player.transform.position.y < -4.2f)
        {
            _player.transform.position = new Vector2(_player.transform.position.x, -4.1f);
        }
        if (_player.transform.position.x > 6.8f)
        {
            _player.transform.position = new Vector2(6.75f, _player.transform.position.y);
        }
        if (_player.transform.position.x < -6.2f)
        {
            _player.transform.position = new Vector2(-6.17f, _player.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Farmer" || collision.tag == "Farmer")
        {
            Destroy(gameObject);
        }
    }

}
