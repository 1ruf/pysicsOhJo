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

    private item nowItem;


    public item SetItem(int ObjectNum)
    {
        switch (ObjectNum)
        {
            case 1:
                nowItem = item.None;
                break;
            case 2:
                nowItem = item.glassess;
                break;
            case 3:
                nowItem = item.vault;
                break;
        }
        return nowItem;
    }
    
}
