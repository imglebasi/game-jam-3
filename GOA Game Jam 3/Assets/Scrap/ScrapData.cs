using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is just a data container for variables relating to scrap
public class ScrapData : MonoBehaviour
{
    //enums for different types of scrap are defined here
    //I used public enums so that other scripts, such as the scrap merchant script,
    //can also use the same enums to read the scrap data

    public enum ScrapType { Gear, CircuitBoard, Battery };
    public enum ScrapCondition { Rusty, Cracked, Sandy}
    public enum ScrapColor { Teal, Brown, Grey}

 


    //the variables defined here are not final, just for testing
    //purposes and we can change them all later
    public ScrapType type;
    public ScrapCondition condition;
    public ScrapColor color;
    public int weight;

    //you can uncomment the update function if you want to test out the script a bit
    //private void Update()
    //{
    //    Debug.Log(Description());
    //    if (Input.GetKeyDown("a")) Randomize();
    //}
    public void Randomize()
    {
        //can be called when generating new scrap to give the scrap random parameters
        type = (ScrapType)Random.Range(0, 3);
        condition = (ScrapCondition)Random.Range(0, 3);
        color = (ScrapColor)Random.Range(0, 3);
        weight = (int)Random.Range(1, 20);
    }

    public string Description()
    {
        //gives a description of the item
        string typeName = type.ToString();
        if (typeName.Equals("CircuitBoard")) typeName = "circuit board"; //no, I couldn't figure out a better way to fix this, mostly because I didn't care that much
        string conditionName = condition.ToString();
        string colorName = color.ToString();

        return "A " + conditionName.ToLower() + ", " + colorName.ToLower() + " " + typeName.ToLower() + " weighing " + weight + " grams.";
        
    }
}
