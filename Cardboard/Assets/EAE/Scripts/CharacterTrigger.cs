using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterTrigger : MonoBehaviour 
{
    [SerializeField]
    private string _nameLayer = "Wall";

    private CharacterMovement.ObjectBlocked _callbackBlocked = null;
    private Action _callbackRelease = null;


    public void AddCallbackTorusPalePicked(CharacterMovement.ObjectBlocked callbackBlocked, Action callbackRelease)
    {
        _callbackBlocked = callbackBlocked;
        _callbackRelease = callbackRelease;
    }
        

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_nameLayer))
        {
            _callbackBlocked(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_nameLayer))
        {
            _callbackRelease();
        }
    }
	
}
