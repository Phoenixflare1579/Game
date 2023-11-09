using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveS 
{
    private static SaveS _current;
    public static SaveS Current
    {
        get 
        {
            if (_current == null)
            {
                _current = new SaveS();
            }
            return _current; 
        }
    }
}
