using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class MyIntData : ScriptableObject
{
    public int value;
    
    public void SetValue(int num)
    {
        value = num;
    }

    public void CompareValue(MyIntData obj)
    {
        if (value >= obj.value)
        {
            
        }
        else
        {
            value = obj.value;
        }
    }

    public void SetValue(MyIntData obj)
    {
        value = obj.value;
    }

    public void UpdateValue(int num)
    {
        value += num;
    }
}
