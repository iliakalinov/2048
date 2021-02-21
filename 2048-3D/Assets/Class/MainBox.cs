using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBox : MonoBehaviour
{
    public PlatformController platformController;
    public GameObject mainBox;
    private Vector3 startPos;
    public GameObject thisBox;
    private float targetPosX;
    private float targetPosY;
    private Rigidbody positionBox;

    public Effects effects;

    private GameObject hit;
    private GameObject pointers;
    private GameObject track;

    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private int Impulse = 25;

    public Progress progress;

    public Action<bool> endGame;

    private bool onActive = true;

    private float positionX;
    private float positionY;

    public GameController GameController;

    private void Awake()
    {
        track = effects.effectTrack;
        pointers = effects.effectPointers;
        track = Instantiate(track, new Vector3(0, 0, 0), Quaternion.identity);
        pointers = Instantiate(pointers, new Vector3(0, 0, 0), Quaternion.identity);
        СhangeVisibility(track, false);
        СhangeVisibility(pointers, false);
    }

    private void Start()
    {
        GenerateMainBox();
    }

    public void GenerateMainBox()
    {
        GameController.NewStep();
        thisBox = Instantiate(mainBox, new Vector3((platformController.GetWidth() + 1) / 2, 2, 1), Quaternion.identity);
        track.transform.position = thisBox.transform.position;
        pointers.transform.position = thisBox.transform.position;
        СhangeVisibility(track, true);
        СhangeVisibility(pointers, true);

        if (thisBox != null)
        {
            positionBox = thisBox.GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {

        if (progress.GetIsGame() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                onActive = true;
                startPos = Input.mousePosition;
                positionY = 0;
            }
            else if (Input.GetMouseButton(0))
            {
                positionX = Input.mousePosition.x - startPos.x;
                positionY = Input.mousePosition.y - startPos.y;
                if (thisBox != null)
                {
                    targetPosX = Mathf.Clamp(thisBox.transform.position.x + positionX, 1, platformController.GetWidth());
                }
            }

            if (Mathf.Abs(positionX) > Mathf.Abs(positionY))
            {
                if (targetPosX != 0)
                {
                    if (thisBox != null)
                    {
                        thisBox.transform.position = new Vector3(Mathf.Lerp(thisBox.transform.position.x, targetPosX, speed * Time.deltaTime),
                                                                thisBox.transform.position.y,
                                                                thisBox.transform.position.z);
                        track.transform.position = thisBox.transform.position;
                        pointers.transform.position = thisBox.transform.position;
                    }
                    else
                    {

                    }
                }
            }

            if (Mathf.Abs(positionY) > 150 && onActive)
            {
                СhangeVisibility(pointers, false);
                СhangeVisibility(track, false);
                if (positionBox!= null)
                {
                    positionBox.AddForce(Vector3.forward * Impulse, ForceMode.Impulse);
                }
                onActive = false;
                Invoke(nameof(GenerateMainBox), .1f);

            }
        }
    }

    private void СhangeVisibility(GameObject gameObject, bool visible)
    {
        gameObject.SetActive(visible);
    }

    private void hideTrack(bool visible = false)
    {
        СhangeVisibility(track, visible);
    }

}
