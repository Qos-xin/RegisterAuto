using Newtonsoft.Json;
using RegisterAuto.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RegisterAuto.Orange
{
    public class OrangeHandle
    {
        HttpClient httpClient = new HttpClient();
        string Token = Guid.NewGuid().ToString("N");

        public MobileInfo MobileInfo { get; set; }
        public DoRegisterData LoginData { get; private set; }

        public OrangeHandle(MobileInfo mobileInfo)
        {
            httpClient.BaseAddress = new Uri("https://termia.juzifenqi.com");
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("okhttp/3.10.0"));
            MobileInfo = mobileInfo;
        }
        public async Task _1StartAdAsync()
        {
            var dic = new Dictionary<string, string>
            {
                { "adSource", "YYB" },
                { "apiToken", Token },
                { "time", DateTime.Now.ToString("yyyyMMddHHmmss") }
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/lous/startAd.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<string>>(content);

        }
        public async Task _2CreateRecordDataAsync()
        {
            var dic = new Dictionary<string, string> {
               {"apiToken",Token},
               {"appVersion","5.0.5"},
               {"deviceNo",MobileInfo.DeviceNo},
               {"ip",MobileInfo.IP},
               {"mobileType",MobileInfo.Model},
               {"mobileVender",MobileInfo.Brand},
               {"mobileVersion",MobileInfo.Version},
               {"networkType",MobileInfo.NetworkType},
               {"networkVender",MobileInfo.NetworkVender},
               {"operate","1"},
               {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
               {"userId",""},
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/recordData/createRecordData.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<string>>(content);
        }
        public async Task _3GetUpdateVersionInfoAsync()
        {
            var dic = new Dictionary<string, string>() {
                {"apiToken",Token},
                {"appType","0"},
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
                {"versionCode","98"},
                {"versionName","5.0.5"},
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/appApi/user/index/getUpdateVersionInfo.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<UpdateVersionData>>(content);

        }
        public async Task _4GetTwoOneActiveAsync()
        {
            var dic = new Dictionary<string, string>() {
                {"apiToken",Token},
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/mallHome/getTwoOneActive.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<string>>(content);

        }
        public async Task _5GetCurrentTimeAsync()
        {
            var dic = new Dictionary<string, string>() {
                {"apiToken",Token},
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/lous/getCurrentTime.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<string>>(content);

        }
        public async Task _6SceneIndexAsync()
        {
            var dic = new Dictionary<string, string>() {
                {"apiToken",Token},
                {"deviceNo",MobileInfo.DeviceNo},
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
                {"type","1"},
                {"userId",""}
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/mallHome/sceneIndex.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<string>>(content);

        }
        public async Task _7GetMIndexBannerByTypeAsync()
        {
            var dic = new Dictionary<string, string>() {
                {"apiToken",Token},
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
                {"type","1"}
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/mallHome/getMIndexBannerByType.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<string>>(content);

        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <returns></returns>
        public async Task _8SendVerifySMSIsCheckAsync()
        {
            var dic = new Dictionary<string, string>() {
                {"apiToken",Token},
                {"flag","1" },
                {"mobile",MobileInfo.Mobile },
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
                {"verifyCode","" },
                {"verifyKey",MobileInfo.IMEI}
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/sendVerifySMSIsCheck.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<string>>(content);

        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        public async Task _9DoRegisterAsync(string VerifyCode)
        {
            var dic = new Dictionary<string, string>() {
                {"accurate",MobileInfo.Accurate},
                {"apiToken",Token},
                {"channelID","YYB"},
                {"equipmentName",MobileInfo.Model},
                {"identity",""},
                {"imei",MobileInfo.IMEI},
                {"latitude",MobileInfo.Latitude.ToString()},
                {"longitude",MobileInfo.Longitude.ToString()},
                {"mobile",MobileInfo.Mobile},
                {"mobileBrand",MobileInfo.Brand},
                {"mobileMaker",MobileInfo.Brand},
                {"password",MobileInfo.Mobile},
                {"recommendCode",""},
                {"terminalType","2"},
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
                {"yzm",VerifyCode},
            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/doregister.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<DoRegisterData>>(content);
            LoginData = result.Data;
        }
        public async Task _10PersonalCenterNewAsync()
        {
            var dic = new Dictionary<string, string>() {
                {"apiToken",Token},
                {"imei",MobileInfo.IMEI},
                {"time",DateTime.Now.ToString("yyyyMMddHHmmss")},
                {"token",LoginData.token},
                {"userId",LoginData.userId.ToString()},

            };
            var httpContent = new FormUrlEncodedContent(dic);
            HttpResponseMessage hrm = await httpClient.PostAsync("/termi/appApi/user/index/personalCenterNew.do", httpContent);
            var content = await hrm.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult<DoRegisterData>>(content);

        }

    }
    public class MobileInfo
    {
        public MobileInfo() { }
        public MobileInfo(string Mobile)
        {
            this.Mobile = Mobile;
        }
        public string Mobile { get; set; }
        public string IP { get; set; }

        public string IMEI { get; set; }
        public string DeviceNo { get; set; }
        /// <summary>
        /// 型号
        /// vivo Xplay5A
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 品牌
        /// XiaoMi
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 系统版本
        /// Android 5.1.1
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// WIFI
        /// </summary>
        public string NetworkType { get; set; }
        /// <summary>
        /// 中国移动 3G
        /// </summary>
        public string NetworkVender { get; set; }
        public string Accurate { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string EquipmentName { get; set; }

        public async Task<bool> LoadInfoAsync()
        {
            try
            {
                Firmware firmware = await Api.PickFirmware();
                this.IMEI = firmware.SERIAL;
                DeviceNo = firmware.getDeviceId;
                Model = firmware.MODEL;
                Brand = firmware.BRAND;
                Version = "Android " + firmware.RELEASE;
                NetworkType = firmware.getNetworkType;
                NetworkVender = firmware.getNetworkOperatorName;
                EquipmentName = firmware.BRAND + " " + firmware.getPhoneType;
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
    public class ApiResult<T>
    {
        public T Data { get; set; }
        public int? ErrorCode { get; set; }
        public string Msg { get; set; }
        public int? Result { get; set; }
    }

    public class UpdateVersionData
    {

        public int id { get; set; }

        public string version { get; set; }

        public string publishTime { get; set; }
        public string updateContent { get; set; }

        public int isForce { get; set; }

        public string content { get; set; }

        public int sort { get; set; }

        public int appType { get; set; }

        public string versionSize { get; set; }

        public string versionUrl { get; set; }

        public string versionCode { get; set; }

        public int versionSpare { get; set; }

        public int isAddressBook { get; set; }

        public string vIsCall { get; set; }
    }

    public class DoRegisterData
    {
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imgurl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string identity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string realname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isTransactionPassword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isWallet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string walletMoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imei { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobileBrand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobileMaker { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string source { get; set; }
    }
}
