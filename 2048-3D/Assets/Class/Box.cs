using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Box : MonoBehaviour
{
    public TextMeshPro[] textBox;
    [SerializeField]
    private int numberBox = 2;
    [SerializeField]
    private int idColor = 1;
    [SerializeField]
    public ColorController colors;

    public GameObject GameController;

    public Effects effects;
    private GameObject newEffects;

    public void Start()
    {
        SetNumberBox(numberBox);
        ChangeColor(idColor);

        GameController = GameObject.Find("GameController");
        newEffects = effects.effectsHit;
    }

    public void SetNumberBox(int number)
    {
        for (int i = 0; i < textBox.Length; i++)
        {
            textBox[i].SetText(number.ToString());
        }
    }

    public int GetNumberBox()
    {
        return numberBox;
    }

    public void ChangeColor(int newColorId)
    {
        this.GetComponent<Renderer>().material.color = colors.Colors[newColorId];
    }

    public int GetIdColor()
    {
        return this.idColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            if (this.idColor == collision.gameObject.GetComponent<Box>().GetIdColor())
            {
                idColor++;
                numberBox *= 2;
                SetNumberBox(numberBox);
                ChangeColor(idColor);
                Destroy(collision.gameObject);

                GameObject delEffects = Instantiate(newEffects, collision.transform.position, Quaternion.identity);
                Destroy(delEffects, 2);

                GameController.GetComponent<GameController>().NewHit(numberBox);
            }
        }
    }

}
