using UnityEngine;
using System;
using Random = System.Random;

public class Bullet : MonoBehaviour
{
    GameObject player;
    float bulletDirection;
    float bulletSpeed = 0.005f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("HungryMan");
        bulletDirection = Mathf.Round(player.transform.rotation.eulerAngles.y);
        this.transform.rotation = Quaternion.Euler(0f, bulletDirection, 0f);
        this.transform.position = player.transform.position;
        print(bulletDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletDirection == 90f)
        {
            this.transform.position -= new Vector3(0f, 0f, bulletSpeed);
        }
        else if (bulletDirection == 180f)
        {
            this.transform.position -= new Vector3(bulletSpeed, 0f, 0f);
        }
        else if (bulletDirection == 270f)
        {
            this.transform.position += new Vector3(0f, 0f, bulletSpeed);
        }
        else if (bulletDirection == 360f || bulletDirection == 0f)
        {
            this.transform.position += new Vector3(bulletSpeed, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Random random = new Random();
        double randomDouble = random.NextDouble();
        if (other.transform.gameObject.name.StartsWith("Wall") || other.transform.gameObject.name.StartsWith("Wander") || other.transform.gameObject.name.StartsWith("Seek"))
        {
            if(randomDouble > 0.5)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
        else if (other.transform.gameObject.name.Contains("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
