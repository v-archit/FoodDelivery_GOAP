using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliverFood : ActivityClass
{
    private bool deliveredFood = false;

    public GameObject deliveryObject;
    public Manager manager;

    
    public float deliveryDuration = 1;

    //public CookFood()
    //{
    //    AddRequiredStates("hasIngredients", true);
    //    AddRequiredStates("hasFood", false);
    //    AddChangedStates("hasIngredients", false);
    //    AddChangedStates("hasFood", true);
    //    Debug.Log("Activity Object set");


    //    activityObject = kitchenObject;



    //}

    private void Start()
    {
        AddRequiredStates("hasFoodForDelivery", true);
        AddChangedStates("hasFoodForDelivery", false);
        AddChangedStates("hasFoodDelivered", true);


        activityObject = deliveryObject;



    }

    public override void ResetState()
    {
        deliveredFood = false;
    }

    public override bool CheckDone()
    {
        return deliveredFood;
	}

	public override void DoActivity()
	{
		StartCoroutine(GetFoodDelivered());
	}

    public override bool InRange(GameObject agent)
    {
        if (agent.transform.position == activityObject.transform.position)
        {
            return true;
        }
        else
            return false;
    }

    public IEnumerator GetFoodDelivered()
    {
        //if it doesnt work start and stop coroutine with strings

        yield return new WaitForSeconds(deliveryDuration);


        deliveredFood = true;

        manager.foodForDelivery -= 3;
        manager.isFoodOrdered = false;

        Debug.Log("Food is delivered");

        yield break;
    }

    

}
