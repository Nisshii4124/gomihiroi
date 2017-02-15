using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Imageクラスを利用するのに必要


public class StartBar : MonoBehaviour
{
    public Image FadeImage;          // フェードに利用する画像保存用変数

    // Startメソッドで値を設定
    bool isFade;        // フェードスイッチ
    bool isFadeIn;      // フェードインフラグ
    bool isFadeOut;     // フェードアウトフラグ
    float alpha;        // アルファ値計算用変数

	// Use this for initialization
	void Start ()
    {
        isFade = true;  // フェードON
        isFadeIn = true;  // フェードインON
        isFadeOut = false; // フェードアウトOFF
        alpha = 1.0f;  // 100％不透明

        // 画像のアルファ値をセット
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);

    }

    // Update is called once per frame
    void Update ()
    {
	    if(isFadeIn == true)
        {
            // 計算用アルファ値を減算
            alpha -= 0.02f;

            // 画像のアルファ値を変更
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);

            // アルファ値がMIN値以下になったら
            if (FadeImage.color.a <= 0.0f)
            {
                isFadeIn = false;                      // フェードスイッチOFF
                isFadeOut = true;                      // フェードインフラグOFF
            }
        }

        if (isFadeOut == true)
        {
            alpha += 0.02f; // 計算用アルファ値を加算

            // 画像のアルファ値を変更
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha);

            // アルファ値がMAX値以上になったら
            if (FadeImage.color.a >= 1.0f)
            {
                isFadeIn = true;                        // フェードスイッチOFF
                isFadeOut = false;                        // フェードアウトフラグOFF
            }
        }

    }
}
