using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Vector3 pos;


    private void Awake()
    {
        if (!Player)
            Player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        pos = Player.position;
        pos.z = -10f;
        pos.y += 1f;

        transform.position = Vector3.Lerp(transform.position, pos, 8f * Time.deltaTime);

    }
}
