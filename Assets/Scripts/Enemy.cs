using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    [SerializeField] int health = 1;
    [SerializeField] float speed = 1;
    [SerializeField] int scorePoints = 100;
    [SerializeField] AudioClip impactClip;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        GameObject[] spwanPoint = GameObject.FindGameObjectsWithTag("SpwanPoint");
        int randomSpwanPoint = Random.Range(0, spwanPoint.Length);
        transform.position = spwanPoint[randomSpwanPoint].transform.position;
    }
    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * Time.deltaTime * speed;
    }
    public void TakeDamage()
    {
        health--;
        AudioSource.PlayClipAtPoint(impactClip, transform.position);

        if (health <= 0)
        {
            GameManager.Instance.Score += scorePoints;
            Destroy(gameObject, 0.1f);        
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage();
        }
    }
}
