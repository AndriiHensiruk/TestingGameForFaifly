using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timeToExplode;
    public int power;
    public Transform[] angles;
    public Explosion explosionPrefab;
    public float distanceExplosion;

    private float currentTimeToExplode;

    
    void Update()
    {
        currentTimeToExplode += Time.deltaTime;
        if (currentTimeToExplode > timeToExplode) Explode();
    }
    public void Explode()
    {
        int i = 0;
        int currentPower = power;
        foreach (Transform side in angles)
        {
            i++;

            RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, side.position);
            if (hitInfo.collider == null)
            {
                currentPower = 0;
            }
            else
            {
                currentPower = power;
            }

            Vector2 direction = new Vector2();
            string position = "vertical";

            if (i == 1) direction = Vector2.up;
            else if (i == 2) direction = Vector2.down;
            else if (i == 3) direction = Vector2.left;
            else if (i == 4) direction = Vector2.right;

            if (i == 3 || i == 4) position = "horizontal";

            Vector2 newDistance = distanceExplosion * direction;

            
            
                InstatiateExplosion(position, currentPower, newDistance);
            
        }

        InstatiateExplosion("center", 0, Vector2.zero);
        
        Destroy(gameObject);
        Handheld.Vibrate();

    }

    public void InstatiateExplosion(string position, int power, Vector2 distance)
    {
        Vector3 newPosition = transform.position;
        newPosition += new Vector3(distance.x, distance.y, 0);
        GameObject explosion = Instantiate(explosionPrefab.gameObject, newPosition, transform.rotation) as GameObject;
        explosion.GetComponent<Explosion>().Detonate(position, power, distance);

    }
}
