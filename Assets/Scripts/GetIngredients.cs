using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetIngredients : ActivityClass
{
    private bool takenIngredients = false;

    public GameObject storeObject;
    public Manager manager;

    public float takeDuration = 2;

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
        AddRequiredStates("hasIngredientsInStore", true);
        AddChangedStates("hasIngredientsForDelivery", true);


        activityObject = storeObject;



    }

    public override void ResetState()
    {
        takenIngredients = false;
    }

    public override bool CheckDone()
    {
        return takenIngredients;
    }

    public override void DoActivity()
    {
        StartCoroutine(TakeIngredients());
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

    public IEnumerator TakeIngredients()
    {
        //if it doesnt work start and stop coroutine with strings

        yield return new WaitForSeconds(takeDuration);


        takenIngredients = true;
        manager.ingredientForDelivery += 4;
        Debug.Log("Ingredients are taken");

        yield break;
    }



}
