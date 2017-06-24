using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla o deslocamento pelo minigame
/// </summary>
public class MyCharacterController : MonoBehaviour {

    public bool isLocked = false;

    public Transform characterObj;
    public Transform refCamera;

    /// <summary>
    /// Fazer por transform - SORRY
    /// </summary>
    public int currentDestination = 0;
    public Transform[] destinations;
    public float timeDesloc = 2;

    public bool isMoving = false;

    public Animator characterAnimator;

    public void Update()
    {
        DetectSpeed();
        IdleRotation();
    }
    private void DetectSpeed()
    {
        if (isMoving)
            characterAnimator.SetFloat("Speed", 1);
        else
            characterAnimator.SetFloat("Speed", 0);
    }
    private void IdleRotation()
    {
        if (isMoving)
            return;

        Quaternion original = characterObj.rotation;
        characterObj.LookAt(refCamera);
        characterObj.eulerAngles = new Vector3(0, characterObj.eulerAngles.y, 0);
        Quaternion target = characterObj.rotation;

        characterObj.rotation = Quaternion.Slerp(original, target, Time.deltaTime * 5);
    }
    /// <summary>
    /// Avanca para o target desejado
    /// </summary>
    /// <param name="cmd"></param>
    public void MoveToTarget(int cmd)
    {
        StartCoroutine(MoveToDestination(cmd));
    }
    public IEnumerator MoveToDestination(int targetDestination)
    {
        currentDestination = targetDestination;
        
        characterAnimator.SetBool("DoAction", false);

        isMoving = true;

        //Fazer movimentacao do perosnagem
        float lerp = 0;
        Vector3 originalPos = characterObj.position;
        while (lerp < 1)
        {
            characterObj.position = Vector3.Lerp(originalPos, destinations[currentDestination].position, lerp);
            lerp += Time.deltaTime / timeDesloc;

            //Rotaciona o personagem em direcao ao destino
            characterObj.LookAt(destinations[currentDestination]);
            characterObj.eulerAngles = new Vector3(0, characterObj.eulerAngles.y, 0);

            yield return new WaitForEndOfFrame();
        }
        
        isMoving = false;

        yield return new WaitForSeconds(1);

        if (currentDestination == 4)
            characterAnimator.SetBool("DoAction", true);
    }
}
