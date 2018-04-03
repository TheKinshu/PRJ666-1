﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField]
    private float currentValue;
    private float damage;
    private float maxValue;
    private bool armorState;

    public Text CurrentValueText;

    public GameObject player;

    private playerHealth health;

    private Animator animator;

    [SerializeField]
    private Image content;
	// Use this for initialization
	void Start () {
        armorState = true;
        player = GameObject.FindGameObjectWithTag("Player");
        health = Object.FindObjectOfType<playerHealth>();
        currentValue = health.getHealth();
        maxValue = health.getHealth();
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        currentValue = health.getHealth();
        CurrentValueText.text = currentValue + "%";
        HandleBar();
        if (currentValue <= 0)
        {
            animator.SetBool("Dead", true);
            Destroy(player.GetComponent<PlayerMovement>());
            Destroy(player.GetComponent<playerShoot>());
        }
	}

    private void HandleBar() {
        if (!armorState) {
            content.fillAmount = Map(currentValue, maxValue);
        }
    }

    public bool setArmorState(bool ar) {
        return armorState = ar;
    }
    private float Map(float value, float MaxH) {
        return (value) / MaxH;
    }
}
