using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
Testing delegates
*/

public class DelegatesTest : MonoBehaviour
{
    //Delegates are variables for functions, you can subtract them and add them
    public delegate void TestDelegate();
    public delegate bool TestBoolDelegate(int x);

    //Delegates created
    private TestDelegate delegateTestFunction;
    private TestBoolDelegate delegateTestBoolFunction;

    //Unity's built in delegates
    private Action actionTest;
    private Action<int, float> testIntAndFloat;
    private Func<int,int,bool> testFuncBool;

    //Test values
    void Start()
    {
        actionTest += () => { Debug.Log("Hello"); };
        actionTest += () =>
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.Log("Hello there");
            }
        };
        actionTest();
    }
    private void testFunction()
    {
        Debug.Log("Do not pray for easier lives. Pray to be stronger men.");
    }

    private void testFunction2()
    {
        Debug.Log("When the sun sets the air doth drizzle dew");
    }

    private bool something(int x)
    {
        return x > 5;
    }
    private bool something2(int x)
    {
        return x > 4;
    }
}
