using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaleFloorTrigger : MonoBehaviour {

    private Action _callbackTorusPale = null;
    private Action _callbackRemoveTorusParent = null;


    public void AddCallbackTorusPalePicked(Action callbackTorusPale, Action callbackRemoveTorusParent)
    {
        _callbackTorusPale = callbackTorusPale;
        _callbackRemoveTorusParent = callbackRemoveTorusParent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Floor"))
        {
            _callbackRemoveTorusParent();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Floor"))
        {
            _callbackTorusPale();
        }
    }
}
