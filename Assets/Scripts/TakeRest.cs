using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TakeRest : ActivityClass
{
    private bool takenRest = false;

    public GameObject restObject;
    public Manager manager;

    public float restDuration = 5;

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
        AddRequiredStates("takeRest", false);
        AddChangedStates("takeRest", true);


        activityObject = restObject;



    }

    public override void ResetState()
    {
        takenRest = false;
    }

    public override bool CheckDone()
    {
        return takenRest;
    }

    public override void DoActivity()
    {
        StartCoroutine(TakeRestChef());
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

    public IEnumerator TakeRestChef()
    {
        //if it doesnt work start and stop coroutine with strings

        yield return new WaitForSeconds(restDuration);


        takenRest = true;
        Debug.Log("Chef is rested");

        yield break;
    }

    

}
