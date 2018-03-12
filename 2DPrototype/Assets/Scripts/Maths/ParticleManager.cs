using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

    public ParticleSystem[] particles;

	// Use this for initialization
	void Start ()
    {

        //Find all children
        int childrenNumber = transform.childCount;
        particles = new ParticleSystem[childrenNumber];

        for (int i = 0; i < childrenNumber; ++i)
        {
            particles[i] = transform.GetChild(i).GetComponent<ParticleSystem>();
        }
            
    }
	
    public void playOnceAt(Vector2 newPosition)
    {
        this.transform.position = newPosition;

        foreach(var element in particles)
        {
            element.Emit(100);
        }
    }

	// Update is called once per frame
	void Update ()
    {

	}
}
