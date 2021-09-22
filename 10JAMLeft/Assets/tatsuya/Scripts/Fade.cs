using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 0.0f;

    public ButtomScript select;
    public string NextChangerSceneName;
    private float red, green, blue, alfa;//�p�l���̐F�A�����x
    private Image fadePanelImage;
    private bool isStart = true;
    private SceneChanger sceneChange;
    private Character player;
    private Goal goal;
    private bool isLoadScene = false;

    private bool isSound;

    private void Start()
    {
        fadePanelImage = GetComponent<Image>();
        red = fadePanelImage.color.r;
        green = fadePanelImage.color.g;
        blue = fadePanelImage.color.b;
        alfa = fadePanelImage.color.a;
        sceneChange = FindObjectOfType<SceneChanger>();
        player = FindObjectOfType<Character>();
        goal = FindObjectOfType<Goal>();
        isSound = false;
    }

    private void Update()
    {
        if (SceneSave.Instance.IsNowScene == "Title")
        {
            if (select.IsPush)
            {
                StartFadeOut();

                if (isLoadScene)
                {
                    sceneChange.ChangeScene("Select");
                }
            }
        }

        if (SceneSave.Instance.IsNowScene.Contains("Game"))
        {
            if (player.IsDeadFlag)
            {
                if (!isSound)
                {
                    SoundManager.Instance.PlaySeByName("�v���C���[�����񂾂Ƃ�");
                    isSound = true;
                }
                StartFadeOut();

                if (isLoadScene)
                {
                    SoundManager.Instance.StopSe();
                    sceneChange.ChangeScene("Over");
                }
            }

            if (goal.IsGoal)
            {
                StartFadeOut();

                if (isLoadScene)
                {
                    SoundManager.Instance.StopSe();
                    sceneChange.ChangeScene("Clear");
                }
            }
        }
    }

    private void StartFadeIn()
    {
        if (isStart)
        {
            fadePanelImage.enabled = true;
            isStart = false;
        }

        alfa -= fadeSpeed;
        SetAlpha();
        if (alfa <= 0)
        {
            fadePanelImage.enabled = false;//�p�l���̕\�����I�t�ɂ���
            isLoadScene = true;
        }
    }

    private void StartFadeOut()
    {
        if (isStart)
        {
            alfa = 0;
            SetAlpha();
            isStart = false;
        }

        fadePanelImage.enabled = true;//�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1)
        {
            isLoadScene = true;
        }
    }

    private void SetAlpha()
    {
        fadePanelImage.color = new Color(red, green, blue, alfa);
    }
}
