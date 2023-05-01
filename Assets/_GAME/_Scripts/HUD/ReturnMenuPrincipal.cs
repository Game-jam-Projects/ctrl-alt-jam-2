using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ReturnMenuPrincipal : MonoBehaviour
{
    public ReturnPainelTelaInicial returnPainel;

    private void OnEnable()
    {
        StopCoroutine(IEEnableScript());
        StartCoroutine(IEEnableScript());
    }
    private void OnDisable()
    {
        returnPainel.enabled = false;
    }


    private IEnumerator IEEnableScript()
    {
        yield return new WaitForSeconds(0.18f);
        returnPainel.enabled = true;
    }
   
}
