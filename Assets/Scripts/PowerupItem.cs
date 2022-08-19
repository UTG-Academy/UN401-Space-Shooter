using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItem : MonoBehaviour
{
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }
}
