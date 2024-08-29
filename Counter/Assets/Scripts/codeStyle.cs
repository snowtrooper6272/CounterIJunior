using System.Collections;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _points;
    
    private Transform[] _arrayPlaces;
    private Vector3 _currentControlPoint;
    private int _numberOfPlaceInArrayPlaces;

    void Start()
    {
        _arrayPlaces = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
            _arrayPlaces[i] = _points.GetChild(i).GetComponent<Transform>();
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentControlPoint, _speed * Time.deltaTime);

        if (transform.position == _currentControlPoint) 
            _currentControlPoint = NextPlaceTakerLogic();
    }

    public Vector3 NextPlaceTakerLogic()
    {
        if (_numberOfPlaceInArrayPlaces < _arrayPlaces.Length - 1)
            _numberOfPlaceInArrayPlaces++;
        else
            _numberOfPlaceInArrayPlaces = 0;

        Vector3 _newControlPoint = _arrayPlaces[_numberOfPlaceInArrayPlaces].transform.position;

        return _newControlPoint;
    }
}

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _aim;

    [SerializeField] float _timeWaitShooting;
    [SerializeField] public float _speed;

    private Rigidbody _rigidbody;

    void Start()
    {
        StartCoroutine(Shooting());
        _rigidbody = GetComponent<Rigidbody>();
    }

    IEnumerator Shooting()
    {
        bool isShooting = true;

        while (isShooting)
        {
            var _vector3direction = (_aim.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            NewBullet.GetComponent<Rigidbody>().velocity = _vector3direction * _speed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
