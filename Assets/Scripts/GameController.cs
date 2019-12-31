using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private WS ws;
    private GameObject museumDataText;
    private GameObject contentBC;
    private GameObject miniBackgroundBC;
    private GameObject navigationBackBackground;
    private GameObject navigationBackText;
    private GameObject infoMapText;
    private GameObject infoGImage;
    private GameObject infoAppText;
    private GameObject googleMap;

    // Bloque de texto y sus componentes
    private GameObject blockText;
    private GameObject museumNameText;
    private GameObject directionText;
    private GameObject phoneText;
    private GameObject secondPhoneText;
    private GameObject scheduleText;
    private GameObject webPageText;
    private GameObject emailText; 


    private bool RequestInProcess;
    private const float LINESPACE = 42f;

	// Use this for initialization
	void Start () {
        ws = GetComponent<WS>();
        museumDataText = GameObject.Find("MuseumDataText");
        contentBC = GameObject.Find("ContentBC");
        miniBackgroundBC = GameObject.Find("MiniBackgroundBC");
        navigationBackBackground = GameObject.Find("NavigationBackBackground");
        navigationBackText   = GameObject.Find("NavigationBackText");
        infoMapText = GameObject.Find("InfoMapText");
        infoGImage = GameObject.Find("InfoG");
        infoAppText = GameObject.Find("InfoAppText");
        googleMap = GameObject.Find("GoogleMap");

        // Bloque de texto y sus componentes
        blockText = GameObject.Find("BlockText");
        museumNameText = GameObject.Find("MuseumNameText");
        directionText = GameObject.Find("DirectionText");
        phoneText = GameObject.Find("PhoneText");
        secondPhoneText = GameObject.Find("SecondPhoneText");
        scheduleText = GameObject.Find("ScheduleText");
        webPageText = GameObject.Find("WebPageText");
        emailText = GameObject.Find("EmailText");

        RequestInProcess = false;

        // Configuración inicial
        GameObject.Find("Museum").SetActive(false);
        GameObject.Find("InfoMap").SetActive(false);
        GameObject.Find("InfoApp").SetActive(false);
        GameObject.Find("GoogleMap").SetActive(false);
        GameObject.Find("MainMenu").SetActive(false);
        GameObject.Find("WhiteBackground").SetActive(false);
        //GameObject.Find("CanvasVuforia").SetActive(false); // Error destroying database(Vuforia)
        GameObject.Find("CanvasUI").SetActive(false);

        GameObject.Find("InfoGeneral").SetActive(false);
        Application.targetFrameRate = 30;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void GetMuseumData()
    {
        navigationBackText.GetComponent<TextMeshProUGUI>().text = "<EL MUSEO";
        museumDataText.GetComponent<TextMeshProUGUI>().text = "";
        if (!RequestInProcess)
            StartCoroutine(UpdateDataMuseum());      
    }

    public void GetInfoMap()
    {
        navigationBackText.GetComponent<TextMeshProUGUI>().text = "<PLANO";
        infoMapText.GetComponent<TextMeshProUGUI>().text = "";
        if (!RequestInProcess)
            StartCoroutine(UpdateDataInfoMap());
    }

    public void GetInfoApp()
    {
        navigationBackText.GetComponent<TextMeshProUGUI>().text = "<COMO FUNCIONA";
        AdjustContent(infoAppText, infoGImage);
    }

    public void GetGoogleMap()
    {
        navigationBackText.GetComponent<TextMeshProUGUI>().text = "<MAPA";
        /*
        if (!RequestInProcess)
            StartCoroutine(UpdateGoogleMap());       
            */
        Application.OpenURL("http://maps.google.com/maps?q=Museo+Arqueologico+del+Puerto+de+la+Cruz");
    }
    //
    public void GetInfoGeneral()
    {
        navigationBackText.GetComponent<TextMeshProUGUI>().text = "<INFO";
        if (!RequestInProcess)
            StartCoroutine(UpdateInfoGeneral());
        
    }

    public void OpenLink()
    {
        Application.OpenURL(webPageText.GetComponent<TextMeshProUGUI>().text);
    }
    
    private IEnumerator UpdateDataMuseum()
    {        
        RequestInProcess = true;
        yield return StartCoroutine(ws.GetMuseumData());
         
        // Actualizando ventana
        yield return museumDataText.GetComponent<TextMeshProUGUI>().text = processTextMuseum(ws.museumModel.result.data.Itop_BLOCK_Museo.cf_2743);
        RequestInProcess = false;
        AdjustContent(museumDataText);
    }

    private IEnumerator UpdateDataInfoMap()
    {
        
        RequestInProcess = true;
        yield return StartCoroutine(ws.GetMuseumData());

        // Actualizando ventana
        yield return infoMapText.GetComponent<TextMeshProUGUI>().text = ws.museumModel.result.data.Itop_BLOCK_Plano.cf_2745;
        RequestInProcess = false;
        AdjustContent(infoMapText);

    }

    private string processTextMuseum(string input)
    {
        string output = "";
        output = Regex.Replace(input, "<br />", "");
        return output;
    }

    private float CalculateHeight(GameObject textMesh)
    {
        int nLines = textMesh.GetComponent<TextMeshProUGUI>().textInfo.lineCount;
        float miniBackgroundHeight = miniBackgroundBC.GetComponent<RectTransform>().sizeDelta.y;
        float navigationBackHeight = navigationBackBackground.GetComponent<RectTransform>().sizeDelta.y;
        float height = LINESPACE * nLines + miniBackgroundHeight + navigationBackHeight;
        return height;
    }

    private float CalculatePosY(GameObject content,float height)
    {
        float y = content.GetComponent<RectTransform>().position.y - (height / 2);
        return y;
    }

    private void AdjustContent(GameObject textMesh, GameObject image = null)
    {
        // Redimensionamiento de ventana
        float height = CalculateHeight(textMesh);
        if (image != null)
            height += infoGImage.GetComponent<RectTransform>().sizeDelta.y + 30f;
    
        contentBC.GetComponent<RectTransform>().sizeDelta = new Vector2(contentBC.GetComponent<RectTransform>().sizeDelta.x, height);

        // Reposicionamiento de la ventana        
        float y = CalculatePosY(contentBC, height);
        contentBC.GetComponent<RectTransform>().Translate(new Vector3(0f, y, 0f));
    }

    /*
    private IEnumerator UpdateGoogleMap()
    {
        yield return StartCoroutine(ws.GoogleMap());
        //googleMap.GetComponent<RawImage>().texture = ws.mapTexture;
    }
    */

    private IEnumerator UpdateInfoGeneral()
    {
        RequestInProcess = true;
        yield return StartCoroutine(ws.GetMuseumData());

        // Actualizando ventana
        yield return museumNameText.GetComponent<TextMeshProUGUI>().text = ws.museumModel.result.data.LBL_BASIC_INFORMATION.t_name;
        yield return directionText.GetComponent<TextMeshProUGUI>().text = ws.museumModel.result.data.LBL_BASIC_INFORMATION.t_direccion;
        yield return phoneText.GetComponent<TextMeshProUGUI>().text = ws.museumModel.result.data.LBL_BASIC_INFORMATION.tel_telefono;
        yield return secondPhoneText.GetComponent<TextMeshProUGUI>().text = ws.museumModel.result.data.LBL_BASIC_INFORMATION.tel_secundario;
        yield return scheduleText.GetComponent<TextMeshProUGUI>().text = processTextMuseum(ws.museumModel.result.data.LBL_BASIC_INFORMATION.cf_2751);
        yield return webPageText.GetComponent<TextMeshProUGUI>().text = ws.museumModel.result.data.LBL_BASIC_INFORMATION.text_web;
        yield return emailText.GetComponent<TextMeshProUGUI>().text = ws.museumModel.result.data.LBL_BASIC_INFORMATION.e_correo;     

        RequestInProcess = false;
        AdjustContentBlockText();
    }

    private void  AdjustContentBlockText()
    {
        // BlockText
        // Redimensionamiento de ventana
        float height = blockText.GetComponent<RectTransform>().sizeDelta.y + 400f; //Fix this     

        contentBC.GetComponent<RectTransform>().sizeDelta = new Vector2(contentBC.GetComponent<RectTransform>().sizeDelta.x, height);

        // Reposicionamiento de la ventana        
        float y = CalculatePosY(contentBC, height);
        contentBC.GetComponent<RectTransform>().Translate(new Vector3(0f, y, 0f));
    }
}
