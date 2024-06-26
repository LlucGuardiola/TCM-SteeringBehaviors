using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    [SerializeField]
    private float weight = 1f;

    public abstract SteeringData GetSteering(SteeringBehaviorController steeringController);

    public float GetWeight()
    {
        return weight;
    }
}
