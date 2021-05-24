using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ModelController : MonoBehaviour
{
    public LayerMask MovementMask;
    public float RayCastDistance = 200f;
    NavMeshAgent _agent;
    Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move to
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RayCastDistance, MovementMask))
            {
                //Debug.Log(hit.collider.name);
                MoveTo(hit.point);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 25f))
            {
                // check if we hit a targetable item
            }
        }
    }

    public void MoveTo(Vector3 point)
    {
        _agent.SetDestination(point);
    }
}
