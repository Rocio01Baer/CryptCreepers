using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]int addedTime = 10;
    [SerializeField] AudioClip impactClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(impactClip, transform.position);
            GameManager.Instance.time += addedTime;
            Destroy(gameObject, 0.1f);
        }
    }
}
