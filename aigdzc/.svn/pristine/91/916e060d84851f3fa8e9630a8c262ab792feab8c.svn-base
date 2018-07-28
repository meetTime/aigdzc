using Dal;
using Model.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Logic
{
    public class ConfigLogic
    {
        #region 区域
        public static int AddRegion(AddRegionRequest request)
        {
            return ConfigDal.AddRegion(request);
        }

        public static void EditRegion(EditRegionRequest request)
        {
            ConfigDal.EditRegion(request);
        }

        public static void DeleteRegion(int regionId)
        {
            ConfigDal.DeleteRegion(regionId);
        }

        public static List<RegionResponse> GetRegionList(RegionQuery query)
        {
            var list = ConfigDal.GetRegionList(query);
            return list;
        }

        public static List<RegionResponse> GetRegionList(int parentId)
        {
            var list = GetRegionList(new RegionQuery{ ParentId = parentId });
            return list;
        }

        public static List<RegionResponse> GetRegionList()
        {
            var list = GetRegionList(new RegionQuery());
            return list;
        }

        public static RegionResponse GetRegion(int regionId)
        {
            return ConfigDal.GetRegion(regionId);
        }
        #endregion

        #region 轮播图
        public static int AddRoundPlay(AddRoundPlayRequest request)
        {
            return ConfigDal.AddRoundPlay(request);
        }

        public static void EditRoundPlay(EditRoundPlayRequest request)
        {
            ConfigDal.EditRoundPlay(request);
        }

        public static void DeleteRoundPlay(int roundPlayId)
        {
            ConfigDal.DeleteRoundPlay(roundPlayId);
        }

        public static List<RoundPlayResponse> GetRoundPlayList(RoundPlayQuery query)
        {
            var list = ConfigDal.GetRoundPlayList(query);
            return list;
        }

        public static List<RoundPlayResponse> GetRoundPlayList()
        {
            var list = GetRoundPlayList(new RoundPlayQuery());
            return list;
        }

        public static RoundPlayResponse GetRoundPlay(int roundPlayId)
        {
            return ConfigDal.GetRoundPlay(roundPlayId);
        }
        #endregion

        #region 友情链接
        public static int AddSiteLink(AddSiteLinkRequest request)
        {
            return ConfigDal.AddSiteLink(request);
        }

        public static void EditSiteLink(EditSiteLinkRequest request)
        {
            ConfigDal.EditSiteLink(request);
        }

        public static void DeleteSiteLink(int siteLinkId)
        {
            ConfigDal.DeleteSiteLink(siteLinkId);
        }

        public static List<SiteLinkResponse> GetSiteLinkList(SiteLinkQuery query)
        {
            var list = ConfigDal.GetSiteLinkList(query);
            return list;
        }

        public static List<SiteLinkResponse> GetSiteLinkList(int channelId)
        {
            var list = GetSiteLinkList(new SiteLinkQuery {  ChannelId = channelId });
            return list;
        }

        public static List<SiteLinkResponse> GetSiteLinkList()
        {
            var list = GetSiteLinkList(new SiteLinkQuery());
            return list;
        }

        public static SiteLinkResponse GetSiteLink(int siteLinkId)
        {
            return ConfigDal.GetSiteLink(siteLinkId);
        }
        #endregion

        #region 关于我们
        public static int AddAboutUs(AddAboutUsRequest request, ApiContext context)
        {
            request.CreatorId = context.AccountId;
            return ConfigDal.AddAboutUs(request);
        }

        public static void EditAboutUs(EditAboutUsRequest request, ApiContext context)
        {
            request.UpdaterId = context.AccountId;
            ConfigDal.EditAboutUs(request);
        }

        public static void DeleteAboutUs(int aboutUsId)
        {
            ConfigDal.DeleteAboutUs(aboutUsId);
        }

        public static List<AboutUsResponse> GetAboutUsList()
        {
            var list = ConfigDal.GetAboutUsList();
            return list;
        }

        public static AboutUsResponse GetAboutUs(int aboutUsId)
        {
            return ConfigDal.GetAboutUs(aboutUsId);
        }
        #endregion
    }
}
