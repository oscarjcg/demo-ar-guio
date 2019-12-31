using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoginModel {

    public int status;
    public Result result;

    [System.Serializable]
    public class Preferences
    {
        public string activity_view;
        public string hour_format;
        public string start_hour;
        public string date_format;
        public string date_format_js;
        public string dayoftheweek;
        public string time_zone;
        public int currency_id;
        public string currency_grouping_pattern;
        public string currency_decimal_separator;
        public string currency_grouping_separator;
        public string currency_symbol_placement;
        public int no_of_currency_decimals;
        public int truncate_trailing_zeros;
        public string end_hour;
        public string currency_name;
        public string currency_code;
        public string currency_symbol;
        public string conv_rate;
    }

    [System.Serializable]
    public class Result
    {
        public string token;
        public object name;
        public object parentName;
        public string lastLoginTime;
        public string lastLogoutTime;
        public string language;
        public int type;
        public bool logged;
        public Preferences preferences;
    }
}


