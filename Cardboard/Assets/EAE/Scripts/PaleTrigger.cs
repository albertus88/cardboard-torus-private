using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaleTrigger : MonoBehaviour {

    private Action _callbackTorusPale = null;
    private Action _callbackRemoveTorusParent = null;


    public void AddCallbackTorusPalePicked(Action callbackTorusPale, Action callbackRemoveTorusParent)
    {
        _callbackTorusPale = callbackTorusPale;
        _callbackRemoveTorusParent = callbackRemoveTorusParent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("TorusStick"))
        {
            _callbackTorusPale();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("TorusStick"))
        {
            _callbackRemoveTorusParent();
        }
    }
}
