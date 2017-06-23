using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla o deslocamento pelo minigame
/// </summary>
public class MyCharacterController : MonoBehaviour {

    public bool isLocked = false;

    public Transform characterObj;

    /// <summary>
    /// Fazer por transform - SORRY
    /// </summary>
    public int currentDestination = 0;
    public Transform[] destinations;
    public float speedDesloc = 2;

    public bool isMoving = false;

    public Animator characterAnimator;

    public void Update()
    {
        DetectInputs();
        DetectSpeed();
    }
    private void DetectSpeed()
    {
        if (isMoving)
            characterAnimator.SetFloat("Speed", 1);
        else
            characterAnimator.SetFloat("Speed", 0);
    }
    public void DetectInputs()
    {

    }
    /// <summary>
    /// Avanca para o proximo ou anterior
    /// </summary>
    /// <param name="cmd"></param>
    public void MoveToTarget(int cmd)
    {

    } 
    public IEnumerator MoveToDestination(int targetDestination)
    {
        currentDestination = targetDestination;
        isMoving = true;

        //Fazer movimentacao do perosnagem
        yield return new WaitForEndOfFrame();

        isMoving = false;
    }
}
