using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Talent
{
    /// <summary>
    /// Tipo de slide base, contendo as funcoes para inicializar um slide
    /// </summary>
    public class BaseSlide : MonoBehaviour
    {
        public Animator slideAnimator;
        
        /// <summary>
        /// Mostra ou esconde esse slide
        /// </summary>
        /// <param name="cmd"></param>
        public virtual void SetSlideActive(bool cmd)
        {
            slideAnimator.SetBool("Open", cmd);
        }
    }
}