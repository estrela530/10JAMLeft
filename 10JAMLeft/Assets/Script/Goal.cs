using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	public bool goalFlag;

    public bool IsGoal
    {
        get => goalFlag;
        set => goalFlag = value;
    }
    
	/// <summary>
	/// Õ“Ë‚µ‚½
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		// Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
		if (collision.gameObject.tag == "Player")
		{
			goalFlag = true;
		}
	}
}
