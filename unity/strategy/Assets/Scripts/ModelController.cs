using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ModelController : MonoBehaviour
{
    public LayerMask MovementMask;
    public float RayCastDistance = 200f;
    public Interactable Focus;
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
        // If we are in the correct state
        if (!GameManager.Instance.State.HasFlag(GameState.PlayerTurn)) return;

        // Move to
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RayCastDistance, MovementMask))
            {
                //Debug.Log(hit.collider.name);
                MoveTo(hit.point);
                RemoveFocus();
            }
        }

        // Right Mouse Button
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log($"Hit: {hit.collider.name}");
                var interactable = hit.collider.gameObject.GetComponentInParent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                    _agent.stoppingDistance = Focus.Radius * .8f;
                    MoveTo(interactable.gameObject.transform.position);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (Focus != newFocus)
        {
            Focus = newFocus;
            Focus.OnFocused(transform);
        }
    }

    void RemoveFocus()
    {
        _agent.stoppingDistance = 0f;
        if (Focus != null)
            Focus.ClearFocus();
        Focus = null;
    }

    public void MoveTo(Vector3 point)
    {
        _agent.SetDestination(point);
    }
}
