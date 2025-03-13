using UnityEngine;

public class RotatingWall : MonoBehaviour
{
    public float rotationSpeed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed += 0.38f;
        this.transform.rotation = Quaternion.Euler(0f, rotationSpeed, 0f);
    }
}
