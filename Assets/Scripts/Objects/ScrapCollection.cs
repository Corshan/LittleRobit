using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCollection : MonoBehaviour
{
    [SerializeField] private playerStats Stats;
    private AudioSource _source;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Stats.scrap++;
        GameEvents.current.scrapTriggerEnter();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        _source.PlayOneShot(clip);
        GameObject.Destroy(gameObject, 2f);
    }
}
