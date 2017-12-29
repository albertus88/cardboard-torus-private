using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public delegate void CallbackAddParent(Pale pale);

    [SerializeField]
    private CharacterMovement _characterMovement;
    [SerializeField]
    private GameObject[] DummyPointsToPutPales;
    [SerializeField]
    private Pale [] _pales;


	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < _pales.Length; i++)
        {
            _pales[i].AddCallbackAddParent(addTorusParent);
        }
	}

    private void addTorusParent(Pale pale)
    {
        pale.transform.parent = _characterMovement.Mechanism;
    }
}
