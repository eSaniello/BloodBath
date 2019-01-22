using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Making a list to store the objects inside the pool
    List<GameObject> objectPool;

    //Amount of objects to pool
    public float PoolAmount;

    //The object that will be pooled
    public GameObject PooledObject;
	
	void Start ()
    {
        //Making sure the list is empty
        objectPool = new List<GameObject>();

        //Adding the pooled object in the list and setting it to inactive using for loop
		for(int i = 0; i < PoolAmount; i++)
        {
            GameObject tempObj = (GameObject)Instantiate(PooledObject);
            tempObj.SetActive(false);
            objectPool.Add(tempObj);
        }
	}
    
    //Creating a public function to pull objects from the pool if they are inactive
    public GameObject GetBullet()
    {
        //Looping through the list
        for(int i = 0; i < objectPool.Count; i++)
        {
            //Checking if the GameObject is inactive in the hierarchy
            if (!objectPool[i].activeInHierarchy)
            {
                //If it is then return the object
                return objectPool[i];
            }
        }
        //If there are no objects found inactive in the hierarchy we create a new one
        //Set it to inactive and return the newly created object
        GameObject tempObj = (GameObject)Instantiate(PooledObject);
        tempObj.SetActive(false);
        objectPool.Add(tempObj);
        return tempObj;
    }
}
