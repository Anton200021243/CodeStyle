using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private Transform _pointsParent;

    private Transform[] _points;
    private Vector3 _nextPoint;
    private int _nextPointIndex;

    private void Start()
    {
        _points = new Transform[_pointsParent.childCount];

        for (int i = 0; i < _pointsParent.childCount; i++)
            _points[i] = _pointsParent.GetChild(i);
    }

    private void Update()
    {
        Transform point = _points[_nextPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, point.position, _moveSpeed * Time.deltaTime);

        if (transform.position == point.position)  
            MoveNextPoint();
    }

    private void MoveNextPoint()
    {
        _nextPointIndex = _nextPointIndex++ % _points.Length;

        Vector3 nextPointVector = _points[_nextPointIndex].transform.position;
        transform.forward = nextPointVector - transform.position; 
    }
}