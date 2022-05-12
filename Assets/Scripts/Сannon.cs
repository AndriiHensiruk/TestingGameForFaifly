using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сannon : MonoBehaviour
{
	[SerializeField] GameObject bullet;

	float fireRate;
	float nextFire;
	public Transform player;
	[SerializeField] float shootingdistance;

	// Use this for initialization
	void Start()
	{
		fireRate = 1f;
		nextFire = Time.time;

	}

	// Update is called once per frame
	void Update()
	{
		if (Vector2.Distance(transform.position, player.position) < shootingdistance)
			CheckIfTimeToFire();
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name.Equals("Player"))
		{
			Destroy(gameObject);
		}
	}
}
