﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCutterCheck : MonoBehaviour
{
    public bool inCutting;
    private Transform player;
    private Vector3 ori;
    public int score;
    public SurfaceEffector2D trackEffector;
    private float oriEffectorSpeed;
    public Emit emitScript;
    // Start is called before the first frame update
    public Vector3 getDelta()
    {
        return (player.position - ori);
    }
    private void Start()
    {
        oriEffectorSpeed = trackEffector.speed;
        inCutting = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            emitScript.emitInit();
            trackEffector.speed = 1;
            player = collision.gameObject.transform;
            ori = player.position;
            inCutting = true;
            score = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            emitScript.clearEmits();
            trackEffector.speed = oriEffectorSpeed;
            inCutting = false;
            Debug.Log("outCutting");
        }
    }
}
