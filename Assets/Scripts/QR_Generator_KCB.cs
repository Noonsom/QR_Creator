using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ZXing;        // QR코드 오픈 라이브러리 헤더
using ZXing.QrCode;
using System.IO;    // QR 생성 후 입출력을 위한 헤더

public class QR_Generator_KCB : MonoBehaviour
{
    // 파일 이름 설정
    public string FIleName;

    // 사용자가 PNG & JPG 중 익스포트 옵션을 선택하면,
    // 해당하는 익스포트 함수가 실행됨.
    public void GeneratePNGCode(string QR_FileName, string QRtext)
    {
        FIleName = QR_FileName;

        SavePNG(generateQR(QRtext));
    }

    public void GenerateJPGCode(string QR_FileName, string QRtext)
    {
        FIleName = QR_FileName;

        SaveJPG(generateQR(QRtext));
    }

    // QR 크기는 256x256 고정, 텍스트 내용을 QR코드 속에 인코딩하는 함수
    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                CharacterSet = "UTF-8",
                Height = height,
                Width = width
            }

        };
        return writer.Write(textForEncoding);
    }

    // QR 인코딩 된 텍스트 내용을 기반으로 하는 QR 코드 텍스처를 생성 (반환)
    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    // 생성된 QR 텍스처를 .PNG 형식으로 익스포트 하는 함수,
    // 저장되는 파일은 현재 실행 경로 아래 "SaveImages" 폴더를 생성하여 그 아래에 저장한다.
    void SavePNG(Texture2D QRTexture)
    {
        var Bytes = QRTexture.EncodeToPNG();

        var dirPath = Application.dataPath + "/../SaveImages/";

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        File.WriteAllBytes(dirPath + FIleName + ".png", Bytes);
    }

    // 생성된 QR 텍스처를 .JPG 형식으로 익스포트 하는 함수
    // 저장되는 파일은 현재 실행 경로 아래 "SaveImages" 폴더를 생성하여 그 아래에 저장한다.
    void SaveJPG(Texture2D QRTexture)
    {
        var Bytes = QRTexture.EncodeToJPG();

        var dirPath = Application.dataPath + "/../SaveImages/";

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        File.WriteAllBytes(dirPath + FIleName + ".jpg", Bytes);
    }
}
