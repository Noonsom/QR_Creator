using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QR_Call : MonoBehaviour
{
    public QR_Generator_KCB QR_Generator;

    // 생성 파일 이름 설정
    public TMP_Text FileName;

    // QR 내부에 작성 될 텍스트 설정
    public TMP_Text InPutText;


    // PNG 형식으로 추출하는 함수, 완료되면 로그에 "Done" 표시
    public void GeneratePNG()
    {
        QR_Generator.GeneratePNGCode(FileName.text, InPutText.text);
        Debug.Log("Done");
    }

    // JPG 형식으로 추출하는 함수, 완료되면 로그에 "Done" 표시
    public void GenerateJPG()
    {
        QR_Generator.GenerateJPGCode(FileName.text, InPutText.text);
        Debug.Log("Done");
    }
}
