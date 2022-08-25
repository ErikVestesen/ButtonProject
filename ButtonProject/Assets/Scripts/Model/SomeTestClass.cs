using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeTestClass
{
    private int _number;

    public SomeTestClass(int number)
    {
        _number = number;
    }

    public void AddToNumber(int addedNumber)
    {
        this._number += addedNumber;
    }

    public int GetNumber()
    {
        return this._number;
    }
}
