
using TMPro;
using UnityEngine;

public class GoalBar : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _text;

    public void SetGoal(string goalName)
    {
        _text.text = "Find " + goalName;
    }
}
