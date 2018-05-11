using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterAuto.Util
{
    public class Firmware
    {
        [JsonProperty("ARCH")]
        public string ARCH { get; set; }
        [JsonProperty("BRAND")]
        public string BRAND { get; set; }
        [JsonProperty("DEVICE")]
        public string DEVICE { get; set; }
        [JsonProperty("DISPLAY")]
        public string DISPLAY { get; set; }
        [JsonProperty("FINGERPRINT")]
        public string FINGERPRINT { get; set; }
        [JsonProperty("GL_RENDERER")]
        public string GL_RENDERER { get; set; }
        [JsonProperty("GL_VENDOR")]
        public string GL_VENDOR { get; set; }
        [JsonProperty("HARDWARE")]
        public string HARDWARE { get; set; }
        [JsonProperty("HOST")]
        public string HOST { get; set; }
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("MANUFACTURER")]
        public string MANUFACTURER { get; set; }
        [JsonProperty("MODEL")]
        public string MODEL { get; set; }
        [JsonProperty("PRODUCT")]
        public string PRODUCT { get; set; }
        [JsonProperty("RELEASE")]
        public string RELEASE { get; set; }
        [JsonProperty("SDK")]
        public string SDK { get; set; }
        [JsonProperty("SERIAL")]
        public string SERIAL { get; set; }
        [JsonProperty("TAGS")]
        public string TAGS { get; set; }
        [JsonProperty("TYPE")]
        public string TYPE { get; set; }
        [JsonProperty("USER")]
        public string USER { get; set; }
        [JsonProperty("connect_mode")]
        public string connect_mode { get; set; }
        [JsonProperty("density")]
        public string density { get; set; }
        [JsonProperty("densityDpi")]
        public string densityDpi { get; set; }
        [JsonProperty("file_hook_package")]
        public string file_hook_package { get; set; }
        [JsonProperty("file_hook_package_open")]
        public string file_hook_package_open { get; set; }
        [JsonProperty("get")]
        public string get { get; set; }
        [JsonProperty("getAddress")]
        public string getAddress { get; set; }
        [JsonProperty("getBSSID")]
        public string getBSSID { get; set; }
        [JsonProperty("getDeviceId")]
        public string getDeviceId { get; set; }
        [JsonProperty("getIpAddress")]
        public string getIpAddress { get; set; }
        [JsonProperty("getJiZhan")]
        public string getJiZhan { get; set; }
        [JsonProperty("getLine1Number")]
        public string getLine1Number { get; set; }
        [JsonProperty("getMacAddress")]
        public string getMacAddress { get; set; }
        [JsonProperty("getMetrics")]
        public string getMetrics { get; set; }
        [JsonProperty("getNetworkCountryIso")]
        public string getNetworkCountryIso { get; set; }
        [JsonProperty("getNetworkOperator")]
        public string getNetworkOperator { get; set; }
        [JsonProperty("getNetworkOperatorName")]
        public string getNetworkOperatorName { get; set; }
        [JsonProperty("getNetworkType")]
        public string getNetworkType { get; set; }
        [JsonProperty("getPhoneType")]
        public string getPhoneType { get; set; }
        [JsonProperty("getRadioVersion")]
        public string getRadioVersion { get; set; }
        [JsonProperty("getSSID")]
        public string getSSID { get; set; }
        [JsonProperty("getSimCountryIso")]
        public string getSimCountryIso { get; set; }
        [JsonProperty("getSimOperator")]
        public string getSimOperator { get; set; }
        [JsonProperty("getSimOperatorName")]
        public string getSimOperatorName { get; set; }
        [JsonProperty("getSimSerialNumber")]
        public string getSimSerialNumber { get; set; }
        [JsonProperty("getSimState")]
        public string getSimState { get; set; }
        [JsonProperty("getString")]
        public string getString { get; set; }
        [JsonProperty("getSubscriberId")]
        public string getSubscriberId { get; set; }
        [JsonProperty("getSubtypeName")]
        public string getSubtypeName { get; set; }
        [JsonProperty("gps")]
        public string gps { get; set; }
        [JsonProperty("location_mode")]
        public string location_mode { get; set; }
        [JsonProperty("scaledDensity")]
        public string scaledDensity { get; set; }
        [JsonProperty("setCpuName")]
        public string setCpuName { get; set; }
        [JsonProperty("sign")]
        public string sign { get; set; }
        [JsonProperty("time")]
        public string time { get; set; }
        [JsonProperty("xdpi")]
        public string xdpi { get; set; }
        [JsonProperty("ydpi")]
        public string ydpi { get; set; }
    }
}
