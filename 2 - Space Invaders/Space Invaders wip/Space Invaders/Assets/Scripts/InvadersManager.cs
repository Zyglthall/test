using UnityEngine;
using System.Collections;

public class InvadersManager : MonoBehaviour
{
	public GameObject invader1Prefab;
	public GameObject invader2Prefab;
	public GameObject invader3Prefab;
	
	private bool goingRight;

	private Transform[] invaders;

	// Use this for initialization
	void Start ()
	{
		invaders = new Transform[55];

		goingRight = false;

		int index = 0;
		GameObject invader = invader1Prefab;
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 11; j++)
			{
				if (i == 0 || i == 1)
				{
					invader = invader1Prefab;
				}
				if (i == 2 || i == 3)
				{
					invader = invader2Prefab;
				}
				if (i == 4)
				{
					invader = invader3Prefab;
				}

				invader = Instantiate(invader) as GameObject;

				invader.transform.position = new Vector3(j * 2.2f, i * 2.2f, 0);

				invader.transform.parent = transform;

				invaders[index] = invader.transform;
				index = index + 1;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (goingRight)
		{
			transform.transform.Translate(10 * Time.deltaTime, 0, 0);
		}
		else
		{
			transform.transform.Translate(-10 * Time.deltaTime, 0, 0);
		}
	}

	public void moveInvadersCloser (bool rightTrigger)
	{
		if (rightTrigger)
		{
			goingRight = false;
		} else 
		{
			goingRight = true;
		}
	}

	public void destroyInvader (Transform invader)
	{
		for (int i = 0; i < invaders.Length; i++)
		{
			if (invaders[i] == invader)
			{
				Destroy(invader.gameObject);
				invaders[i] = null;
			}
		}
	}
}
