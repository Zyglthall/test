using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	/// <summary>
	/// The bullet prefab.
	/// </summary>
	public GameObject bulletPrefab;

	private GUIText livesLabel;

	// Use this for initialization
	void Start ()
	{
		livesLabel = GameObject.Find("LivesLabel").guiText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Left movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-16 * Time.deltaTime, 0, 0);
		}
		// Right movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(16 * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(bulletPrefab) as GameObject;
			bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
			bullet.rigidbody2D.velocity = new Vector2(0, 20);
		}
	}

	private void shoot()
	{

	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.CompareTag("Invader"))
		{
			Destroy(collision.collider.gameObject);
			transform.position = new Vector3(0, transform.position.y, 0);
		}
	}
}
