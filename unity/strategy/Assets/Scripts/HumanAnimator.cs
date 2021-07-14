using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAnimator : MonoBehaviour
{
    public float SmoothTime = .1f;
    Animator _animiator;
    public float Speed = 0f;
    public float MaxSpeed = 20f;
    NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _animiator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            Speed += SmoothTime;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            Speed -= SmoothTime;
        }
        *
        Speed = Mathf.Clamp(Speed, 0f, MaxSpeed);

        float speedPercent = Speed / MaxSpeed;
        */
        //Debug.Log($"mag: {_agent.velocity.magnitude} speed: {_agent.speed}");
        float speedPercent = _agent.velocity.magnitude / _agent.speed;
        //Debug.Log($"SpeedPercent: {speedPercent}");
        _animiator.SetFloat("SpeedPercent", speedPercent, SmoothTime, Time.deltaTime);
    }
}
