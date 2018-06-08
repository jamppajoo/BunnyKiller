﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecalPool : MonoBehaviour
{

	public int maxDecals = 250;
	public float decalSizeMin = 0.5f;
	public float decalSizeMax = 1.5f;
	private ParticleSystem decalParticleSystem;

	private int particleDecalDataIndex;
	private ParticleDecalData[] particleData;
	private ParticleSystem.Particle[] particles;

	void Start ()
	{
		decalParticleSystem = GetComponent<ParticleSystem>();
		particleData = new ParticleDecalData[maxDecals];
		particles = new ParticleSystem.Particle[maxDecals];

		for (int i = 0; i < maxDecals; i++)
		{
			particleData[i] = new ParticleDecalData();
		}
	}

	public void ParticleHit(ParticleCollisionEvent particleCollisionEvent)
	{
		SetParticleData(particleCollisionEvent);
		DisplayParticles();
	}

	void SetParticleData(ParticleCollisionEvent particleCollisionEvent)
	{
		//records collision position rotation size and color

		if (particleDecalDataIndex >= maxDecals)
		{
			particleDecalDataIndex = 0;
		}

		particleData[particleDecalDataIndex].position = particleCollisionEvent.intersection;
		Vector3 particleRotationEuler = Quaternion.LookRotation(particleCollisionEvent.normal).eulerAngles;
		particleRotationEuler.z = Random.Range(0, 360);
		particleData[particleDecalDataIndex].rotation = particleRotationEuler;
		particleData[particleDecalDataIndex].size = Random.Range(decalSizeMin, decalSizeMax);

		particleDecalDataIndex++;
	}

	void DisplayParticles()
	{
		for (int i = 0; i < particleData.Length; i++)
		{ 
			particles[i].position = particleData[i].position;
			particles[i].rotation3D = particleData[i].rotation;
			particles[i].startSize = particleData[i].size;
		}

		decalParticleSystem.SetParticles(particles, particles.Length);
	}
}
