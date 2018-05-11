using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RegisterAuto.Util
{
    public static class Api
    {
        public static string BaseUrl = "http://automate/api";
        //public static string BaseUrl = "http://automate-api.fcleyuan.com/api";

        public async static Task<List<Mission>> GetMissionList()
        {
            try
            {
                var rt = await Api.BaseUrl.AppendPathSegment("mission/list").GetJsonAsync<ApiResult<List<Mission>>>();
                return rt.Result<List<Mission>>();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async static Task<List<Unit>> GetMissionUnitList(string missionId)
        {
            try
            {
                var rt = await Api.BaseUrl.AppendPathSegment("unit/list").SetQueryParam("missionId", missionId).GetJsonAsync<ApiResult<List<Unit>>>();
                return rt.Result<List<Unit>>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async static Task<List<Channel>> GetMissionChannelList(string missionId)
        {
            try
            {
                var rt = await Api.BaseUrl.AppendPathSegment("Channel/list").SetQueryParam("missionId", missionId).GetJsonAsync<ApiResult<List<Channel>>>();
                return rt.Result<List<Channel>>();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async static Task<Firmware> PickFirmware()
        {
            try
            {
                var rt = await Api.BaseUrl.AppendPathSegment("firmware/random").GetJsonAsync<ApiResult<Firmware>>();
                return rt.Result<Firmware>();
            }
            catch (Exception )
            {
                return null;
            }
        }

        public async static Task<List<AppInfo>> GetAppInfoList()
        {
            try
            {
                var rt = await Api.BaseUrl.AppendPathSegment("AppInfo/GetList").GetJsonAsync<ApiResult<List<AppInfo>>>();
                return rt.Result<List<AppInfo>>();
            }
            catch (Exception )
            {
                return null;
            }
        }

        public static T Result<T>(this ApiResult<T> rt)
        {
            if (rt.Code != 0)
                throw new Exception(rt.Msg);
            return rt.Data;
        }


    }
}
