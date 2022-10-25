using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicListener : MonoBehaviour
{
    public GameEnums.TriggerBehaviour Trigger = GameEnums.TriggerBehaviour.OnTriggerEnter;

    public string CompareTagName;

    public UnityEvent<Collider> TriggerEnterCallback;
    public UnityEvent<Collider> TriggerExitCallback;

    private void OnTriggerEnter(Collider other)
    {
        if (Trigger == GameEnums.TriggerBehaviour.OnTriggerEnter || Trigger == GameEnums.TriggerBehaviour.Both)
        {
            if (other.tag == CompareTagName || CompareTagName == "")
            {
                TriggerEnterCallback.Invoke(other);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Trigger == GameEnums.TriggerBehaviour.OnTriggerExit || Trigger == GameEnums.TriggerBehaviour.Both)
        {
            if (other.tag == CompareTagName || CompareTagName == "")
            {
                TriggerExitCallback.Invoke(other);
            }
        }
    }
}

