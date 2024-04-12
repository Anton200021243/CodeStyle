using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private Transform _target;

    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_delay);
        }
    }
}