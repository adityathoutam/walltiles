using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{

public Vector3 DefaultPos;
public Vector3 ZoomInPos;
public float TransitionTime;


bool isMoving = false;
void OnMouseEnter()
{
    if(!isMoving)
     StartCoroutine(moveToX(DefaultPos,ZoomInPos, TransitionTime));
}
void OnMouseExit()
{
    if(!isMoving)
     StartCoroutine(moveToX(ZoomInPos, DefaultPos, TransitionTime));
}

IEnumerator moveToX(Vector3 fromPosition, Vector3 toPosition, float duration)
{

    if (isMoving)
    {
        yield break;
    }
    isMoving = true;

    float counter = 0;


    Vector3 startPos = fromPosition;

    while (counter < duration)
    {
        counter += Time.deltaTime;
        this.transform.position= Vector3.Lerp(startPos, toPosition, counter / duration);
        yield return null;
    }

    isMoving = false;
}
}