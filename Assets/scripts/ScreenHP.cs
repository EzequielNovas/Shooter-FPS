using UnityEngine;
using UnityEngine.UI;
public class ScreenHP : MonoBehaviour
{
    public Text text;
    public HP hp;
    private void Update() => text.text = hp.value + "/100";
}
