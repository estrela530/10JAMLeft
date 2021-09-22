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
	/// �Փ˂�����
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		// �Փ˂��������Player�^�O���t���Ă���Ƃ�
		if (collision.gameObject.tag == "Player")
		{
			goalFlag = true;
		}
	}
}
