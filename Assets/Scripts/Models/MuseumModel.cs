using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MuseumModel
{

    public int status;
    public Result result;

    [System.Serializable]
    public class LBLBASICINFORMATION
    {
        public string t_name;
        public string t_direccion;
        public string tel_telefono;
        public string tel_secundario;
        public string cf_2751;
        public string text_web;
        public string e_correo;
    }

    [System.Serializable]
    public class ItopBLOCKRedesSoc
    {
        public string text_facebook;
    }

    [System.Serializable]
    public class ItopBLOCKMuseo
    {
        public string cf_2743;
    }

    [System.Serializable]
    public class ItopBLOCKPlano
    {
        public string cf_2745;
    }

    [System.Serializable]
    public class ItopBLOCKCreditos
    {
        public string t_credito;
        public string mail_correootro;
        public string cf_2774;
        public string web_webotro;
        public string t_direccionotro;
        public string cf_2779;
        public string tel_telefonootro;
    }

    [System.Serializable]
    public class ItopBLOCKOtrosDatos
    {
        public string sw_googlemaps;
        public string t_latitud;
        public string t_longitud;
    }

    [System.Serializable]
    public class LBLCUSTOMINFORMATION
    {
        public string created_user_id;
            public string assigned_user_id;
            public string createdtime;
            public string modifiedtime;
    }

    [System.Serializable]
    public class Fields
    {
        public LBLBASICINFORMATION LBL_BASIC_INFORMATION;
        public ItopBLOCKRedesSoc Itop_BLOCK_RedesSoc;
        public ItopBLOCKMuseo Itop_BLOCK_Museo;
        public ItopBLOCKPlano Itop_BLOCK_Plano;
        public ItopBLOCKCreditos Itop_BLOCK_Creditos;
        public ItopBLOCKOtrosDatos Itop_BLOCK_OtrosDatos;
        public LBLCUSTOMINFORMATION LBL_CUSTOM_INFORMATION;
    }

    [System.Serializable]
    public class LBLBASICINFORMATION2
    {
        public string t_name;
        public string t_direccion;
        public string tel_telefono;
        public string tel_secundario;
        public string cf_2751;
        public string text_web;
        public string e_correo;
    }

    [System.Serializable]
    public class ItopBLOCKRedesSoc2
    {
        public string text_facebook;
    }

    [System.Serializable]
    public class ItopBLOCKMuseo2
    {
        public string cf_2743;
    }

    [System.Serializable]
    public class ItopBLOCKPlano2
    {
        public string cf_2745;
    }

    [System.Serializable]
    public class ItopBLOCKCreditos2
    {
        public string t_credito;
        public string mail_correootro;
        public string cf_2774;
        public string web_webotro;
        public string t_direccionotro;
        public string cf_2779;
        public string tel_telefonootro;
    }

    [System.Serializable]
    public class ItopBLOCKOtrosDatos2
    {
        public string sw_googlemaps;
        public string t_latitud;
        public string t_longitud;
    }

    [System.Serializable]
    public class LBLCUSTOMINFORMATION2
    {
        public string created_user_id;
        public string assigned_user_id;
        public string createdtime;
        public string modifiedtime;
    }

    [System.Serializable]
    public class Data
    {
        public LBLBASICINFORMATION2 LBL_BASIC_INFORMATION;
        public ItopBLOCKRedesSoc2 Itop_BLOCK_RedesSoc;
        public ItopBLOCKMuseo2 Itop_BLOCK_Museo;
        public ItopBLOCKPlano2 Itop_BLOCK_Plano;
        public ItopBLOCKCreditos2 Itop_BLOCK_Creditos;
        public ItopBLOCKOtrosDatos2 Itop_BLOCK_OtrosDatos;
        public LBLCUSTOMINFORMATION2 LBL_CUSTOM_INFORMATION;
    }

    [System.Serializable]
    public class Result
    {
        public string name;
        public string id;
        public Fields fields;
        public Data data;
        public bool inventory;
    }

}


