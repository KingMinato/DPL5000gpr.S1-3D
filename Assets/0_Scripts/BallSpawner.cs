using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private float upForce = 1f;
    [SerializeField] private float sideForce = .1f;

    [SerializeField] private float timer = 0;
    [SerializeField] private float spawnRate = 0.3f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            float xForce = Random.Range(-sideForce, sideForce);
            float yForce = Random.Range(upForce / 2f, upForce);
            float zForce = Random.Range(-sideForce, sideForce);
            Vector3 force = new Vector3(xForce, yForce, zForce);
            GameObject ball = ObjectPool.Instance.SpawnFromPool("Ball", transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = force;

            timer = 0f;
        }
    }
}
