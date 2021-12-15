using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliverIngredients : ActivityClass
{
    private bool deliveredIngredients = false;

    public GameObject kitchenObject;
    public Manager manager;

    public float deliverDuration = 1;

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
        AddRequiredStates("hasIngredientsForDelivery", true);
        AddChangedStates("hasIngredientsForDelivery", false);
        AddChangedStates("hasIngredientsDelivered", true);


        activityObject = kitchenObject;



    }

    public override void ResetState()
    {
        deliveredIngredients = false;
    }

    public override bool CheckDone()
    {
        return deliveredIngredients;
    }

    public override void DoActivity()
    {
        StartCoroutine(GetIngredientsDelivered());
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

    public IEnumerator GetIngredientsDelivered()
    {
        //if it doesnt work start and stop coroutine with strings

        yield return new WaitForSeconds(deliverDuration);


        deliveredIngredients = true;
        manager.ingredients += 4;
        manager.ingredientForDelivery -= 4;

        Debug.Log("Ingredients are delivered");

        yield break;
    }



}
