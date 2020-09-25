using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1f)]
    private float fireRate = 1f;
    [SerializeField]
    [Range(1f,10f)]
    private int damage = 1;

    [SerializeField]
    private float weaponRange = 100f;

    [SerializeField]
    private Camera tpsCam;

    [SerializeField]
    private Transform firePoint;

    private float timer;

    /*[SerializeField]
    private ParticleSystem muzzleParticle; //Don't Forget to assign the particle in the inspector view !!
    */

    /*[SerializeField]
    private AudioSource gunFireSource; //Don't forget to assign the audio source in the inspector view AND audio component in the player 
    & to uncheck Play On awake
    */
    void Start()
    {
        tpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 0f;
                Fire();
            }
        }
    }

    private void Fire()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, weaponRange))
        {
            Debug.Log(hit.transform.name);

            var health = hit.collider.GetComponent<HealthManager>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        //muzzleParticle.Play();
        //gunFireSource.Play();
    }
}
