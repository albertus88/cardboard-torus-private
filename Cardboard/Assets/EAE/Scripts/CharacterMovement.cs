using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    
    public delegate void ObjectBlocked(GameObject GameObject);


	[SerializeField]
	private GameObject _minPoint = null;
	[SerializeField]
	private GameObject _maxPoint = null;
	[SerializeField]
	private GameObject _mechanism = null;
	[SerializeField]
	private float _velocityForward = 1.0f;
	[SerializeField]
	private float _velocityRotationX = 15.0f;
	[SerializeField]
	private float _velocityMovementMechanism = 1.0f;
    [SerializeField]
    private CharacterTrigger [] _characterTrigger = null;
    [SerializeField]
    private GameObject _dummyPointCheckCollisions = null;

	public JoystickInput JoystickInput { set; get; }

    public Transform Mechanism { get { return _mechanism.transform; } }

    private GameObject _objectBlocked = null;



	// Use this for initialization
	void Start () 
    {
        if (_characterTrigger != null && _characterTrigger.Length > 0)
        {
            for (int i = 0; i < _characterTrigger.Length; i++)
            {
                _characterTrigger[i].AddCallbackTorusPalePicked(OnObjectBlocked, OnReleaseObjectBlocked);
            }

        }

#if UNITY_EDITOR
		InitJoystickPC();
#else
		InitJoystickMobile();
#endif
	}

    void OnObjectBlocked(GameObject objectBlocked)
    {
        _objectBlocked = objectBlocked;
    }

    void OnReleaseObjectBlocked()
    {
        _objectBlocked = null;
    }

	void InitJoystickMobile()
	{
		JoystickInput = gameObject.AddComponent<JoystickInputMobile> ();
	}

	void InitJoystickPC()
	{
		JoystickInput = gameObject.AddComponent<JoystickInputPC> ();
	}
	
    bool canMove(float movementForward)
    {
        if (_objectBlocked == null)
        {
            return true;
        }

        Vector3 localPosition = _dummyPointCheckCollisions.transform.InverseTransformPoint(_objectBlocked.transform.position);
        if (movementForward > 0.0f &&  localPosition.z > 0)
        {
            return false;
        }
        else if(movementForward < 0.0f && localPosition.z < 0)
        {
            return false;
        }

        return true;
    }
	// Update is called once per frame
	void Update () 
	{
		if (!JoystickInput) 
		{
			return;
		}
            
        if (Mathf.Abs(JoystickInput.CharacterValues.MovementForward) > 0.0f && canMove(JoystickInput.CharacterValues.MovementForward)) 
        {
			transform.position += transform.forward * JoystickInput.CharacterValues.MovementForward * Time.deltaTime * _velocityForward;
		}

        if (Mathf.Abs (JoystickInput.CharacterValues.RotationXVelocity) > 0.0f && canMove(JoystickInput.CharacterValues.MovementForward)) 
		{
			transform.Rotate(Vector3.up * _velocityRotationX * Time.deltaTime * JoystickInput.CharacterValues.RotationXVelocity);
		}

		if (Mathf.Abs (JoystickInput.CharacterValues.MovementMechanism) > 0.0f) 
		{	
			if (JoystickInput.CharacterValues.MovementMechanism > 0.0f)
			{
				Vector3 deltaMovement = Time.deltaTime * _velocityMovementMechanism * Vector3.up;

				if ((_mechanism.transform.position + deltaMovement).y < _maxPoint.transform.position.y)
				{
					_mechanism.transform.position += deltaMovement;
				}
			}
			else
			{
				Vector3 deltaMovement = Time.deltaTime * _velocityMovementMechanism * Vector3.down;

				if ((_mechanism.transform.position + deltaMovement).y > _minPoint.transform.position.y)
				{
					_mechanism.transform.position += deltaMovement;
				}
			}
		}
			
	}


    void OnDrawGizmos() 
    {
        Debug.DrawRay(transform.position - transform.forward * 1.5f , transform.forward, Color.red, 16.0f);
       
    }
}
