using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pale : MonoBehaviour {

    [SerializeField]
    private PaleTrigger _paleTrigger = null;
    [SerializeField]
    private PaleFloorTrigger _paleFloorTrigger = null;

    private int _numberTouches = 0;

    private Transform _parent = null;

    void Start()
    {
        _parent = transform.parent;
        _paleTrigger.AddCallbackTorusPalePicked(OnAddTorusParent, OnRemoveTorusParent);
        _paleFloorTrigger.AddCallbackTorusPalePicked(OnAddTorusParent, OnRemoveTorusParent);
    }

    private GameController.CallbackAddParent _callbackAddParent = null;
	

    private void OnRemoveTorusParent()
    {
        if (_numberTouches <= 0)
        {
            return;
        }

        if (_numberTouches == 2)
        {
            transform.parent = _parent;
        }

        _numberTouches--;

    }

    private void OnAddTorusParent()
    {
        if (_numberTouches >= 2)
        {
            return;
        }

        _numberTouches++;

        if (_numberTouches == 2)
        {
            _callbackAddParent(this);
        }

    }

    public void AddCallbackAddParent(GameController.CallbackAddParent callbackAddParent)
    {
        _callbackAddParent = callbackAddParent;
    }
}
