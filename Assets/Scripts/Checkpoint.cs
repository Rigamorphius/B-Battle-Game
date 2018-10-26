﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour {

    private bool isActivated = false;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float inactivatedRotationSpeed = 100, activatedRotationSpeed = 300;

    [SerializeField]
    private float inactivatedScale = 1, activatedScale = 1.5f;

    [SerializeField]
    private Color inactivatedColor, activatedColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void Update() {
        UpdateRotation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the checkpoint");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
        }
    }

    public void SetIsActivated(bool value) {
        isActivated = value;
        UpdateScale();
        UpdateColor();
    }

    private void UpdateRotation() {
        float rotationSpeed = inactivatedRotationSpeed;

        if (isActivated) {
            rotationSpeed = activatedRotationSpeed;
        }

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void UpdateScale() {
        float scale = inactivatedScale;

        if (isActivated)
        {
            scale = activatedScale;
        }
        transform.localScale = Vector3.one * scale;
   }

    private void UpdateColor() {
        Color color = inactivatedColor;

        if (isActivated)
        {
            color = activatedColor;
        }
        spriteRenderer.color = color;
    }

}
