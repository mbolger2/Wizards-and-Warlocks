using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 target;

    public GameObject spell1;
    public GameObject spell2;
    public Transform spellTransform;
    public bool canFire;
    private float timer;
    private float timeBetweenFiring = 0;

    public GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();   
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        cursor.transform.position = target;

        Vector3 rotation = target - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (canFire == false)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenFiring )
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetButton("Fire1") && canFire)
        {
            canFire = false;
            Instantiate(spell1, spellTransform.position, Quaternion.identity);
            timeBetweenFiring = .125f;
        }

        if (Input.GetButton("Fire2") && canFire)
        {
            canFire = false;
            Instantiate(spell2, spellTransform.position, Quaternion.identity);
            timeBetweenFiring = .75f;
        }
    }
}
