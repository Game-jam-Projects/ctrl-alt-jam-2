using UnityEngine;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    public Selectable objetoSelecionavel;
    public Selectable objetoSelecionavelParaCima;
    public Selectable objetoSelecionavelParaBaixo;
    public Selectable objetoSelecionavelParaEsquerda;
    public Selectable objetoSelecionavelParaDireita;

    void Start()
    {
        Navigation nav = new Navigation();
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnUp = objetoSelecionavelParaCima;
        nav.selectOnDown = objetoSelecionavelParaBaixo;
        nav.selectOnLeft = objetoSelecionavelParaEsquerda;
        nav.selectOnRight = objetoSelecionavelParaDireita;

        objetoSelecionavel.navigation = nav;
    }
}
