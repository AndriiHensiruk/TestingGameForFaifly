using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed =8f;
    private Vector3 targetPos;
    public Transform wallPosition;
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField] private GameObject sheeld;
    public float distToWallk = 2f;
    public AudioClip audioClip;

    Rigidbody2D rb;

    //public Bomb bombPrefab;

    void Start()
    {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector3 moveDirection)
    {
        targetPos += moveDirection* distToWallk;
    }

    public void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Handheld.Vibrate();
            GetComponent<AudioSource>().PlayOneShot(audioClip);
        }

        if (collision.tag == "Wall" || collision.tag == "Obstacle")
        {
            moveSpeed = 0f;
            Vector3 newPosition = transform.position;
            targetPos = newPosition;
            Handheld.Vibrate();
            GetComponent<AudioSource>().PlayOneShot(audioClip);

        }

        if (collision.tag =="Shoes")
        {
            sheeld.SetActive(true);
            Destroy(collision.gameObject);
            Handheld.Vibrate();
            GetComponent<AudioSource>().PlayOneShot(audioClip);

        }


        if (collision.tag == "Lava")
        { if(!sheeld.activeInHierarchy)
             Destroy(gameObject);
            Handheld.Vibrate();
            GetComponent<AudioSource>().PlayOneShot(audioClip);
        }
    }

   public void DropBomb()
    {
        Instantiate(bombPrefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
