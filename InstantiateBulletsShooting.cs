using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
        var wait = new WaitForSeconds(_delay);


        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return wait;
        }
    }
}