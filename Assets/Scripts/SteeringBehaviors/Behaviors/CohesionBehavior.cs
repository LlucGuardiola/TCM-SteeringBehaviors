using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class CohesionBehavior : Steering
{
    private Transform[] targets;

    void Start()
    {
        SteeringBehaviorController[] agents = FindObjectsOfType<SteeringBehaviorController>();
        targets = new Transform[agents.Length - 1];
        int count = 0;

        foreach (SteeringBehaviorController agent in agents)
        {
            if (agent.gameObject != gameObject)
            {
                targets[count++] = agent.transform;
            }
        }
    }

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        SteeringData steering = new SteeringData();

        Vector2 average = Vector2.zero;

        foreach (Transform target in targets)
        {
            average += new Vector2(target.position.x, target.position.y);
        }
        average /= targets.Length;

        steering.linear += average + new Vector2(transform.position.x, transform.position.y).normalized * steeringController.maxAcceleration;
        steering.angular = 0;

        return steering;
    }
}
