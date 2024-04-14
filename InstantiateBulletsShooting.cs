using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private Transform _target;

    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Transform newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return wait;
        }
    }
}