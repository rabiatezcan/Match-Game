using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
	[SerializeField] ParticleSystem _smokeFX;
	public void StartGame()
	{
		RecipeCompleteCheckHelper.OnRecipeCompleted += PlayFX;
	}

	public void GameOver()
	{
        RecipeCompleteCheckHelper.OnRecipeCompleted -= PlayFX;
    }

    private void PlayFX()
	{
		_smokeFX.Play();
	}

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
