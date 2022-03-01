using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFarm : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private float _speed;
    private int _point;

    [SerializeField] GameObject _right;

    private Vector2 _currentPoint;

    private int _currentIndex;

    private void Start()
    {
        _currentPoint = points[0].position;

        ChooseDirection();
    }

    private void Update()
    {
        Walk();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            Destroy(gameObject);
        }
    }

    private void Walk()
    {
        float _step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint, _step);

        if(Vector2.Distance(transform.position, _currentPoint)< 0.1f)
        {
            nextPosition();
        }
    }

    private void nextPosition()
    {
        if(_currentIndex+1<points.Count)
        {
            _right.SetActive(true);
     
            _currentIndex = _currentIndex + 1;
        }
        else
        {
            _currentIndex = 0;
        }

        _currentPoint = points[_currentIndex].position;

        ChooseDirection();
    }

    private void ChooseDirection()
    {
    
        this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
    }

}
