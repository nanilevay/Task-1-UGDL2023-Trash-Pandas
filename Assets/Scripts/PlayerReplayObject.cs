using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReplayObject : ReplayObject
{
    private SpriteRenderer sr;
    private ParticleSystem deathBurstParticles;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        deathBurstParticles = GetComponentInChildren<ParticleSystem>();
        deathBurstParticles.Stop();
    }

    public override void SetDataForFrame(ReplayData data)
    {
        // typecast the data
        PlayerReplayData playerData = (PlayerReplayData)data;
        // position
        this.transform.position = playerData.position;
        // sprite alpha
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, playerData.spriteAlpha);
        // facing dir
        sr.flipX = !playerData.facingRight;
        // particle burst on death
        if (playerData.deathThisFrame)
        {
            deathBurstParticles.Play();
        }
    }
}