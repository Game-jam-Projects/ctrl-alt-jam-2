using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{

    public enum Cena
    {
        // Adiciona automaticamente as cenas ao Enum
        // a partir do método GetSceneNameFromBuildIndex()
        // da classe SceneUtility.
        // Remove o primeiro valor "None" do Enum
        // para que apenas as cenas do projeto sejam listadas.
        None,
        CenasDoProjeto
    }

    public Cena cenaSelecionada;

  

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Jeano/Atualizar Cenas")]
    public static void AtualizarCenas()
    {
        System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/_GAME/_Scripts/CenasEnum.cs", false);
        sw.WriteLine("public enum Cena {");
        foreach (UnityEditor.EditorBuildSettingsScene s in UnityEditor.EditorBuildSettings.scenes)
        {
            if (s.enabled)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(s.path);
                sw.WriteLine("\t" + name + ",");
            }
        }
        sw.WriteLine("}");
        sw.Flush();
        sw.Close();
        UnityEditor.AssetDatabase.Refresh();
    }
#endif
}
