using Api.App_Start;
using Logic;
using Model.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ConfigController : BaseApiController
    {
        #region 区域
        [HttpPost]
        public HttpResponseMessage AddRegion(AddRegionRequest request)
        {
            var response = ConfigLogic.AddRegion(request);
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpPost]
        public HttpResponseMessage EditRegion(EditRegionRequest request)
        {
            ConfigLogic.EditRegion(request);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpGet]
        public HttpResponseMessage DeleteRegion(int regionId)
        {
            ConfigLogic.DeleteRegion(regionId);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpGet]
        public HttpResponseMessage GetRegionList(int parentId)
        {
            var response = ConfigLogic.GetRegionList(parentId);
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetRegionList()
        {
            var response = ConfigLogic.GetRegionList();
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpGet]
        public HttpResponseMessage GetRegion(int regionId)
        {
            var response = ConfigLogic.GetRegion(regionId);
            return ApiHelper.CreateHttpResponseMessage(response);
        }
        #endregion

        #region 轮播图
        [HttpPost]
        public HttpResponseMessage AddRoundPlay(AddRoundPlayRequest request)
        {
            var response = ConfigLogic.AddRoundPlay(request);
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpPost]
        public HttpResponseMessage EditRoundPlay(EditRoundPlayRequest request)
        {
            ConfigLogic.EditRoundPlay(request);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpGet]
        public HttpResponseMessage DeleteRoundPlay(int roundPlayId)
        {
            ConfigLogic.DeleteRoundPlay(roundPlayId);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetRoundPlayList()
        {
            var response = ConfigLogic.GetRoundPlayList();
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpGet]
        public HttpResponseMessage GetRoundPlay(int roundPlayId)
        {
            var response = ConfigLogic.GetRoundPlay(roundPlayId);
            return ApiHelper.CreateHttpResponseMessage(response);
        }
        #endregion

        #region 友情链接
        [HttpPost]
        public HttpResponseMessage AddSiteLink(AddSiteLinkRequest request)
        {
            var response = ConfigLogic.AddSiteLink(request);
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpPost]
        public HttpResponseMessage EditSiteLink(EditSiteLinkRequest request)
        {
            ConfigLogic.EditSiteLink(request);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpGet]
        public HttpResponseMessage DeleteSiteLink(int siteLinkId)
        {
            ConfigLogic.DeleteSiteLink(siteLinkId);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpPost]
        public HttpResponseMessage GetSiteLinkList(SiteLinkQuery query)
        {
            var response = ConfigLogic.GetSiteLinkList(query);
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpGet]
        public HttpResponseMessage GetSiteLinkList(int channelId)
        {
            var response = ConfigLogic.GetSiteLinkList(channelId);
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetSiteLinkList()
        {
            var response = ConfigLogic.GetSiteLinkList();
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpGet]
        public HttpResponseMessage GetSiteLink(int siteLinkId)
        {
            var response = ConfigLogic.GetSiteLink(siteLinkId);
            return ApiHelper.CreateHttpResponseMessage(response);
        }
        #endregion

        #region 关于我们
        [HttpPost]
        public HttpResponseMessage AddAboutUs(AddAboutUsRequest request, ApiContext context)
        {
            var response = ConfigLogic.AddAboutUs(request, ApiContext);
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpPost]
        public HttpResponseMessage EditAboutUs(EditAboutUsRequest request, ApiContext context)
        {
            ConfigLogic.EditAboutUs(request, ApiContext);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpGet]
        public HttpResponseMessage DeleteAboutUs(int aboutUsId)
        {
            ConfigLogic.DeleteAboutUs(aboutUsId);
            return ApiHelper.CreateHttpResponseMessage();
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetAboutUsList()
        {
            var response = ConfigLogic.GetAboutUsList();
            return ApiHelper.CreateHttpResponseMessage(response);
        }

        [HttpGet]
        public HttpResponseMessage GetAboutUs(int aboutUsId)
        {
            var response = ConfigLogic.GetAboutUs(aboutUsId);
            return ApiHelper.CreateHttpResponseMessage(response);
        }
        #endregion
    }
}
