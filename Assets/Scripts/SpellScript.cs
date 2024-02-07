using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody2D rb;
    public float force;
    public float lifeTime;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        Vector3 rotation = transform.position - mousePosition;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
