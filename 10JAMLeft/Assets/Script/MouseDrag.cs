using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Vector3 objectPoint;    //�u���b�N�̃|�W�V�����ϊ��p
    Vector3 screenPoint;    //�u���b�N�̃X�N���[���|�W�V����

    bool clickedObject;     //�N���b�N���ꂽ�Ƃ���Ƀu���b�N�����邩
    Vector3 justMousePosition;
    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        objectPoint = transform.position;   //������
        clickedObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�N���b�N������
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            //�u���b�N������ꍇ
            if(Physics.Raycast(ray,out hit))
            {
                clickedObject = true;
            }
        }

        //�L�[�𗣂����炻���Ƀu���b�N��z�u
        if (Input.GetMouseButtonUp(0))
        {
            clickedObject = false;
        }

        if (clickedObject)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            //Block�̍��W�����[���h����X�N���[����
            objectPoint = Camera.main.WorldToScreenPoint(mousePosition - transform.position);

            //Block�̃|�W�V�������}�E�X�̈ʒu��
            screenPoint = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                objectPoint.z);

            //Block�̍��W���X�N���[�����烏�[���h��
            objectPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        }
        //�u���b�N�̃|�W�V�����ɕω������蓖��
        transform.position = objectPoint;

    }
}
