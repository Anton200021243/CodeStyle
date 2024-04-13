using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _moveSpeed = 10;

    private Transform _pointsParent;
    private int _nextPointIndex;

    private void Start()
    {
        _points = new Transform[_pointsParent.childCount];

        for (int i = 0; i < _pointsParent.childCount; i++)
            _points[i] = _pointsParent.GetChild(i).transform;
    }

    private void Update()
    {
        Transform point = _points[_nextPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, point.position, _moveSpeed * Time.deltaTime);

        if (transform.position == point.position)  
            SetNextPoint();
    }

    private Vector3 SetNextPoint()
    {
        _nextPointIndex = (_nextPointIndex++) % _points.Length;

        Vector3 nextPointVector = _points[_nextPointIndex].transform.position;
        transform.forward = nextPointVector - transform.position;

        return nextPointVector;   
    }
}