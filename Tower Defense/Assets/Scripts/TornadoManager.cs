using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoManager : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public AudioSource AudioSource;//tornado
    public AudioSource AudioSource2;//Wind
    public AudioSource AudioSource3;//tunder
    public AudioSource AudioSource4;//siren

    public AudioClip Tunder;
    public AudioClip Wind;
    public AudioClip Siren;
    public AudioClip Tornado;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TornadoTurnOn());

        // StartCoroutine(SirenTurnOn());
        //StartCoroutine(TornadoTurnOff());
        // StartCoroutine(SirenTurnOff());

        // StartCoroutine(TunderTurnOn());
        // StartCoroutine(TunderTurnOff());

        ParticleSystem.Stop();
        AudioSource2.Stop();
        AudioSource = GetComponent<AudioSource>();
        AudioSource2 = GetComponent<AudioSource>();
        AudioSource3 = GetComponent<AudioSource>();
        AudioSource4 = GetComponent<AudioSource>();

        



    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator TornadoTurnOn()
    {
        yield return new WaitForSeconds(5);
        AudioSource3.Play();
        AudioSource2.Play();

        yield return new WaitForSeconds(5);
        AudioSource4.Play();
        //Tornado
        //Wind
        yield return new WaitForSeconds(5); 
        ParticleSystem.Play();
        AudioSource.Play();
        

        yield return new WaitForSeconds(7);
        ParticleSystem.Stop();
        AudioSource.Stop();
        AudioSource2.Stop();

        yield return new WaitForSeconds(2);
        AudioSource4.Stop();

        yield return new WaitForSeconds(1);
        AudioSource3.Stop();
        
    }
    /*
    IEnumerator TunderTurnOn()
    {
        //Siren
        yield return new WaitForSeconds(5);
        AudioSource3.Play();
    }


    IEnumerator SirenTurnOn()
    {
        yield return new WaitForSeconds(10);
        AudioSource4.Play();
    }
    */
    /*
        IEnumerator TornadoTurnOff()
         {
             //Tornado
            // Wind
            yield return new WaitForSeconds(22);
            ParticleSystem.Stop();
            AudioSource.Stop();
            AudioSource2.Stop();
        }
       IEnumerator SirenTurnOff()
        {
           // Siren
            yield return new WaitForSeconds(23);
           AudioSource4.Stop();
        }

        IEnumerator TunderTurnOff()
        {
           // Siren
            yield return new WaitForSeconds(24);
            AudioSource3.Stop();
        }
        */
}
