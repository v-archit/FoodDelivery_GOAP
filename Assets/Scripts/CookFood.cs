using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CookFood : ActivityClass
{
    private bool cookedFood = false;

    public GameObject kitchenObject;
    public Manager manager;

    public float cookDuration = 4;

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
        AddRequiredStates("hasIngredients", true);
        AddChangedStates("hasFood", true);
        //Debug.Log("Activity Object set");


        activityObject = kitchenObject;



    }

    public override void ResetState()
	{
        cookedFood = false;
	}

    public override bool CheckDone()
    {
        return cookedFood;
    }

    public override void DoActivity()
    {
        StartCoroutine(Cooking());
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

    public IEnumerator Cooking()
    {
        //if it doesnt work start and stop coroutine with strings

        yield return new WaitForSeconds(cookDuration);


        cookedFood = true;
        manager.ingredients -= 2;
        manager.cookedFood += 4;
        Debug.Log("Food is cooked");
        
        yield break;
    }

    

}
