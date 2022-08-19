using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject projectilePrefab;
    public GameObject explosionPrefab;
    public int health = 3;
    public GameObject healthUI;
    public float multishotTime = 5f;
    public bool hasMultishot = false;





    // Start is called before the first frame update
    void Start()
    {
        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.GetComponent<TextMeshProUGUI>().text = "Health: " + health;

        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.2f)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.2f)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -4.2f)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 8.2f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            if (hasMultishot == true)
            {
                Instantiate(projectilePrefab, transform.position + Vector3.left, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right, Quaternion.identity);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            health = health - 1;
            Destroy(coll.gameObject);
            if (health <= 0)
            {
                Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
                Destroy(gameObject);
            }
        }
        else if (coll.gameObject.tag == "PowerupItem")
        {
            Destroy(coll.gameObject);
            hasMultishot = true;
            Invoke("StopMultishot", multishotTime);
            print("Multishot started");


        }
        else if (coll.gameObject.tag == "HealthItem")
        {
            Destroy(coll.gameObject);
            health = health + 1;
            print("Player healled");
        }


    }

    void StopMultishot()
    {
        hasMultishot = false;
        print("Multishot ended");
    }


}
