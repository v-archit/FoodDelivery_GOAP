using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public int ingredients = 2;
	public int cookedFood = 0;
	public int foodForDelivery = 0;
	public int ingredientForDelivery = 0;
	public bool isFoodOrdered = false;

	public Text text;
	public Toggle toggle;

	public Dictionary<string, bool> GlobalState()
	{
		Dictionary<string, bool> state = new Dictionary<string, bool>();

		state.Add("hasIngredients", (ingredients >= 2));
		state.Add("hasFood", (cookedFood >= 2));
		state.Add("hasFoodForDelivery", (foodForDelivery >= 3));
		state.Add("hasIngredientsForDelivery", (ingredientForDelivery >= 4));
		state.Add("hasFoodDelivered", !isFoodOrdered);
		state.Add("hasIngredientsDelivered", (ingredients >= 15));
		state.Add("hasIngredientsInStore", true);
		state.Add("takeRest", !(cookedFood >= 10));

		return state;
	}

	private void Update()
	{
		isFoodOrdered = toggle.isOn;
		text.text = "Ingredients " + ingredients + "\nCooked Food " + cookedFood + "\nFood Delivery " + foodForDelivery + "\nIngredient Delivery " + ingredientForDelivery + "\nIngredients Required " + !(ingredients >= 15) + "\nTake Rest " + (cookedFood >= 10);
	}

	
}
