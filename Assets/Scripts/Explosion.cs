using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Transform horizontal;
    public Transform vertical;
    public Transform center;
    public float ttl;

    // Start is called before the first frame update
   
    public void Detonate(string position, int power, Vector2 distance)
    {
        horizontal.gameObject.SetActive(false);
        vertical.gameObject.SetActive(false);
        center.gameObject.SetActive(false);
        Destroy(gameObject, ttl);

        if (power > 0 || position == "center")
        {

            if (position == "vertical")
            {
                vertical.gameObject.SetActive(true);
            }
            else if (position == "horizontal")
            {
                horizontal.gameObject.SetActive(true);
            }
            else
            {
                center.gameObject.SetActive(true);
            }
        }
        
        if (power > 0)
        {
            power--;

            Vector2 newPosition = transform.position;
            newPosition += distance;
            Debug.Log("power!");
            GameObject explosion = Instantiate(gameObject, newPosition, transform.rotation) as GameObject;
            explosion.GetComponent<Explosion>().Detonate(position, power, distance);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
