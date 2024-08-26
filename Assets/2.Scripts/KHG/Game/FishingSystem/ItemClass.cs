using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass
{
    public enum item
    {
        None = 0,
        vault = 1,
        glassess = 2
    }

    public item nowItem;


    public item SetItem(int ObjectNum)
    {
        switch (ObjectNum)
        {
            case 0:
                nowItem = item.None;
                break;
            case 1:
                nowItem = item.glassess;
                break;
            case 2:
                nowItem = item.vault;
                break;
        }
        return nowItem;
    }
    
}
