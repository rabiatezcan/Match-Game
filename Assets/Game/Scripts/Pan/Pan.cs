using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{

	#region TriggerBehaviour
	public void TriggerEnterBehaviour(Collider other)
	{
		Vegetable vegetable = other.GetComponentInParent<Vegetable>();

		vegetable.OnPanArea = true;
	}
	
	public void TriggerExitBehaviour(Collider other)
	{
        Vegetable vegetable = other.GetComponentInParent<Vegetable>();

        vegetable.OnPanArea = false;
    }
	#endregion
}
