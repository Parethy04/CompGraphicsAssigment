using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform _Target;
    [SerializeField] Transform player;
    NavMeshAgent _Agent;
    bool _IsActive = true;
    public bool _IsHunting = false;

    bool Spotted;
    // Start is called before the first frame update
    void Start()
    {
        _Agent = this.GetComponent<NavMeshAgent>();
        Destination();
        _Target = this.transform;
        _IsActive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destination();
    }
    private void Destination()
    {
        if (Spotted)
        {
            _Agent.SetDestination(player.position);
        }
        else if (_IsActive)
        {
            StartCoroutine(DesLocation());
            _IsActive = false;
        }
        else if (_IsHunting)
        {
            _Agent.SetDestination(player.position);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Spotted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && Spotted)
        {
            StartCoroutine(countdown());
        }
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(3);
        Spotted = false;
        Debug.Log("lost");
    }
    IEnumerator DesLocation()
    {
        _IsActive = false;
        _Agent.SetDestination(new Vector3(Random.Range(-219, 85), Random.Range(0, 0), Random.Range(-53, 150)));
        Debug.Log(_Agent.destination);
        yield return new WaitForSeconds(8);
        _IsActive = true;
        Debug.Log("new location");
    }
}
