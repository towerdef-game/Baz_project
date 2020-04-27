using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject DestroyBarrier;
    public float WallHealth = 2f;
    public bool wallIsDestroyed = false;
    public AudioSource AudioSource;
    public AudioClip Wall;

    public void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WallHealth == 0 && !wallIsDestroyed)
        {
            WallDestroyed();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Enemy")
            {

            WallHealth--;
            AudioSource.Play();
           
            }
    }

    public void WallDestroyed()
    {
        Instantiate(DestroyBarrier, transform.position, Quaternion.Euler(90, 0, 0));
        wallIsDestroyed = true;
        Destroy(gameObject);
    }
}
