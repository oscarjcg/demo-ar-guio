using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WS : MonoBehaviour {

    private LoginModel loginModel;
    public MuseumModel museumModel;

    /*
    private string urlGoogleMap;
    private float lat = 28.417063f;
    private float lon = -16.552316f;
    public Texture2D mapTexture;

    private int zoom = 17;
    private int mapWidth = 640;
    private int mapHeight = 640;

    private enum mapType {  hybrid, terrain, roadmap, satellite }
    private mapType mapSelected;
    private int scale;
    

    public IEnumerator GoogleMap()
    {
        
        urlGoogleMap = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C28.417063,-16.552316&key=AIzaSyA8EwKTYMQadj28NttQBD4Tw4wu303r8fs";
        WWW www = new WWW(urlGoogleMap);
        yield return www;
        yield return mapTexture = www.texture;
        
        yield return null;
    }
    */

    public IEnumerator GetMuseumData()
    {
        // Petición de token y museo
        yield return StartCoroutine(OnResponse(GetRequestToken()));      
    }



    private IEnumerator OnResponse(UnityWebRequest req)
    {
        // Petición del token
        yield return req.SendWebRequest();

        loginModel = JsonUtility.FromJson<LoginModel>(req.downloadHandler.text);

        // Petición al museo
        yield return StartCoroutine(RequestMuseum());
    }
    
    private UnityWebRequest GetRequestToken()
    {
        var request = new UnityWebRequest(Apis.Login, "POST");

        // Autorización
        string codigoAutorizacion = "demo" + ":" + "demo";
        byte[] codigoAutorizacionBytes = System.Text.Encoding.UTF8.GetBytes(codigoAutorizacion);

        // Parametro json
        string bodyJsonString = "{\r\n\t\"userName\": \"" + "demo" + "\",\r\n\t\"password\": \"" + "demo" + "\",\r\n\t\"params\" :\r\n\t{ 	\r\n\t\t\"language\" : \"es_es\"\r\n\t}\r\n}";
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);

        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        // Cabeceras
        request.SetRequestHeader("authorization", "Basic " + System.Convert.ToBase64String(codigoAutorizacionBytes));
        request.SetRequestHeader("content-type", "application/json");
        request.SetRequestHeader("accept", "application/json");
        request.SetRequestHeader("x-encrypted", "0");
        request.SetRequestHeader("x-api-key", "ndJ2aHF@tc9PS174OyNo&JByV6sXzfCzaemvrNSE93hpL0RhQWV1ILbxIgdPu3q0EkTw#ZiH8lcDjR4FOU6o7CYTQZAnM2KjixlGkD5bWeGBpftKMwrAuv8XmYUs%q5g");
        request.SetRequestHeader("cache-control", "no-cache");

        return request;
    }
          
    private IEnumerator RequestMuseum()
    {

        var request = new UnityWebRequest(Apis.Museum, "GET");

        // Autorización
        string codigoAutorizacion = "demo" + ":" + "demo";
        byte[] codigoAutorizacionBytes = System.Text.Encoding.UTF8.GetBytes(codigoAutorizacion);

        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        // Cabeceras
        request.SetRequestHeader("authorization", "Basic " + System.Convert.ToBase64String(codigoAutorizacionBytes));
        request.SetRequestHeader("content-type", "application/json");
        request.SetRequestHeader("accept", "application/json");
        request.SetRequestHeader("x-encrypted", "0");
        request.SetRequestHeader("x-api-key", "ndJ2aHF@tc9PS174OyNo&JByV6sXzfCzaemvrNSE93hpL0RhQWV1ILbxIgdPu3q0EkTw#ZiH8lcDjR4FOU6o7CYTQZAnM2KjixlGkD5bWeGBpftKMwrAuv8XmYUs%q5g");
        request.SetRequestHeader("cache-control", "no-cache");
        request.SetRequestHeader("x-token", loginModel.result.token);
        request.SetRequestHeader("x-condition", "{\"fieldName\":\"rel_guiamuseo\",\"value\":\"MUSEO ARQUEOLOGICO DEL PUERTO DE LA CRUZ\",\"operator\":\"e\"}");


        yield return request.SendWebRequest();
        //Debug.Log("Response Museum : " + request.downloadHandler.text);//

        museumModel = JsonUtility.FromJson<MuseumModel>(request.downloadHandler.text);
    }
}
