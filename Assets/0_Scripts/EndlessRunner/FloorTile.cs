using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    [SerializeField] private float destroyTimer = 5f;
    [SerializeField] private int spaceBetweenTiles = 300;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Add Score
            ObjectPool.Instance.SpawnFromPool("FloorTile", transform.position + new Vector3(0f, 0f, spaceBetweenTiles), Quaternion.identity);
            Invoke(nameof(RemoveTile), destroyTimer);
        }
    }

    private void RemoveTile()
    {
        gameObject.SetActive(false);
    }
}
