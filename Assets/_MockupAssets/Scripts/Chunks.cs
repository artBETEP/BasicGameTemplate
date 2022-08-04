using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour
{
    public Transform player;
    public float activateDistance = 100f;
    public Transform[] chunks;

    // Start is called before the first frame update
    void Start()
    {
        if (player.gameObject == null)
            player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform t in chunks)
            t.gameObject.SetActive(Vector3.Distance(player.position, t.position) < activateDistance);
    }
}
