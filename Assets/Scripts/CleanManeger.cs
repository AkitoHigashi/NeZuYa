using UnityEngine;

public class CleanManeger : MonoBehaviour
{
   public bool AllCleanDirt()
    {
        // "Dirt"�^�O�̃I�u�W�F�N�g���V�[�����Ō���
        GameObject[] dirtObjects = GameObject.FindGameObjectsWithTag("Dirt");

        // ����I�u�W�F�N�g���P���Ȃ����true�i���ꂢ�j
        return dirtObjects.Length == 0;
    }
    public bool AllCleanBubble()
    {
        GameObject[] BubbleObjects = GameObject.FindGameObjectsWithTag("Bubble");

        return BubbleObjects.Length == 0;

    }
}
