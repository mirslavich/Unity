using UnityEngine;
using UnityEngine.AI;

public class NavAgentMovement : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;
    private float defaultSpeed;
    private float defaultAngularSpeed;
    [SerializeField] private float _waterResistance=1.3f;
    [SerializeField] private float _sandResistance=1.2f;
    private NavMeshHit _navMeshHit;
    private readonly string _water = "Water";
    private readonly string _sand = "Sand";
    private int waterArea;
    private int sandArea;

    private void Start()
    {
        _camera=Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        defaultSpeed = _agent.speed;
        defaultAngularSpeed = _agent.angularSpeed;
        waterArea = NavMesh.GetAreaFromName(_water);
        sandArea = NavMesh.GetAreaFromName(_sand);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
        if (!_agent.SamplePathPosition(NavMesh.AllAreas,0.0f,out _navMeshHit))
        {
            if ((_navMeshHit.mask& (1<<waterArea))!=0)
            {
                ChangeSpeedAndAngular(_waterResistance);
            }
            else if ((_navMeshHit.mask & (1<<sandArea))!=0)
            {
                ChangeSpeedAndAngular(_sandResistance);
            }
            else
            {
                _agent.speed = defaultSpeed;
                _agent.angularSpeed = defaultAngularSpeed;
            }
        }
    }

    private void ChangeSpeedAndAngular(float resistance)
    {
        _agent.speed = defaultSpeed / resistance;
        _agent.angularSpeed = defaultAngularSpeed / resistance;
    }
}
