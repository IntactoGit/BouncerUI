using UnityEngine;

/// <summary>
/// Класс, отвечающий за передвижение кубика.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] 
    private float _forceValue = 250;
    
    private Rigidbody _rigidbody;
    private Vector3 _startPosition = Vector3.zero;
    private Vector3 _target;
    private Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        // Создаем луч из позиции мыши
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            // Зануляем скорость
            _rigidbody.velocity = Vector3.zero;
            
            // Двигаем кубик к заданной точке
            MoveTowardsSelectedPoint(hitInfo);
        }
    }

    private void MoveTowardsSelectedPoint(RaycastHit hitInfo)
    {
        // Вычисляем направление движения
        var direction = (hitInfo.point - transform.position).normalized;

        // Придаем игроку силу в указанном направлении
        _rigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * _forceValue);
    }
}