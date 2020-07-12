using UnityEngine;

public class LevelController : MonoBehaviour
{
    public void AdjustFill(float targetFill, float fillSpeed)
    {
        Renderer renderer = GetComponent<Renderer>();
        float curFill = renderer.material.GetFloat("_Fill");

        float destFill = Mathf.MoveTowards(curFill, targetFill, fillSpeed * Time.deltaTime);

        renderer.material.SetFloat("_Fill", destFill);
    }
}
