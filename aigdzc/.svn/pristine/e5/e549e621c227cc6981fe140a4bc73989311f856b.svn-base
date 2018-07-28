using CCITU.Common;
using Model.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Dao;

namespace Dal
{
    public class ConfigDal
    {
        #region 区域
        public static int AddRegion(AddRegionRequest request)
        {
            Hashtable ht = new Hashtable();
            BuildRegionRequest(request, ht);
            return Convert.ToInt32(DataSources.Default.ExecuteScalar("AddRegion", null, null, ht));
        }

        public static void EditRegion(EditRegionRequest request)
        {
            Hashtable ht = new Hashtable();
            ht.Add("RegionId", request.RegionId);
            BuildRegionRequest(request, ht);
            DataSources.Default.ExecuteNonQuery("EditRegion", null, null, ht);
        }

        private static void BuildRegionRequest(AddRegionRequest request, Hashtable ht)
        {
            ht.Add("Name", request.Name);
            ht.Add("ParentId", request.ParentId);
            ht.Add("SortNumber", request.SortNumber);
        }

        public static void DeleteRegion(int regionId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("RegionId", regionId);
            DataSources.Default.ExecuteNonQuery("DeleteRegion", null, null, ht);
        }

        public static List<RegionResponse> GetRegionList(RegionQuery query)
        {
            Hashtable ht = new Hashtable();
            List<StatementCondition> list = new List<StatementCondition>();
            if (query.RegionIds != null & query.RegionIds.Count > 0)
            {
                ht.Add("RegionIds", DbUtils.ToWhereInParam(query.RegionIds));
                list.Add(new StatementCondition("RegionIds", true));
            }
            if (query.ParentId.HasValue)
            {
                ht.Add("ParentId", query.ParentId.Value);
                list.Add(new StatementCondition("ParentId", true));
            }
            if (!string.IsNullOrEmpty(query.Name))
            {
                ht.Add("Name", query.Name);
                list.Add(new StatementCondition("Name", true));
            }
            return DataSources.Default.QueryCollection<RegionResponse>("GetRegion", null, list, ht).ToList();
        }

        public static RegionResponse GetRegion(int regionId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("RegionId", regionId);
            List<StatementCondition> list = new List<StatementCondition>();
            list.Add(new StatementCondition("RegionId", true));
            return DataSources.Default.Query<RegionResponse>("GetRegion", null, list, ht);
        }
        #endregion

        #region 轮播图
        public static int AddRoundPlay(AddRoundPlayRequest request)
        {
            Hashtable ht = new Hashtable();
            BuildRoundPlayRequest(request, ht);
            return Convert.ToInt32(DataSources.Default.ExecuteScalar("AddRoundPlay", null, null, ht));
        }

        public static void EditRoundPlay(EditRoundPlayRequest request)
        {
            Hashtable ht = new Hashtable();
            ht.Add("RoundPlayId", request.RoundPlayId);
            BuildRoundPlayRequest(request, ht);
            DataSources.Default.ExecuteNonQuery("EditRoundPlay", null, null, ht);
        }

        private static void BuildRoundPlayRequest(AddRoundPlayRequest request, Hashtable ht)
        {
            ht.Add("AssociatedArticleId", request.AssociatedArticleId);
            ht.Add("ChannelId", request.ChannelId);
            ht.Add("ImageUrl", request.ImageUrl);
        }

        public static void DeleteRoundPlay(int roundPlayId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("RoundPlayId", roundPlayId);
            DataSources.Default.ExecuteNonQuery("DeleteRoundPlay", null, null, ht);
        }

        public static List<RoundPlayResponse> GetRoundPlayList(RoundPlayQuery query)
        {
            Hashtable ht = new Hashtable();            
            List<StatementCondition> list = new List<StatementCondition>();
            if (query.RoundPlayIds != null && query.RoundPlayIds.Count > 0)
            {
                ht.Add("RoundPlayIds", DbUtils.ToWhereInParam(query.RoundPlayIds));
                list.Add(new StatementCondition("RoundPlayIds", true));
            }
            if (query.AssociatedArticleId.HasValue)
            {
                ht.Add("AssociatedArticleId", query.AssociatedArticleId.Value);
                list.Add(new StatementCondition("AssociatedArticleId", true));
            }
            if (query.ChannelId.HasValue)
            {
                ht.Add("ChannelId", query.ChannelId.Value);
                list.Add(new StatementCondition("ChannelId", true));
            }
            if (query.ShowCount.HasValue)
            {
                ht.Add("Count", query.ShowCount.Value);
                list.Add(new StatementCondition("Top", true));
            }
            return DataSources.Default.QueryCollection<RoundPlayResponse>("GetRoundPlay", null, list, ht).ToList();
        }

        public static RoundPlayResponse GetRoundPlay(int roundPlayId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("RoundPlayId", roundPlayId);
            List<StatementCondition> list = new List<StatementCondition>();
            list.Add(new StatementCondition("RoundPlayId", true));
            return DataSources.Default.Query<RoundPlayResponse>("GetRoundPlay", null, list, ht);
        }
        #endregion

        #region 友情链接
        public static int AddSiteLink(AddSiteLinkRequest request)
        {
            Hashtable ht = new Hashtable();
            BuildSiteLinkRequest(request, ht);
            return Convert.ToInt32(DataSources.Default.ExecuteScalar("AddSiteLink", null, null, ht));
        }

        public static void EditSiteLink(EditSiteLinkRequest request)
        {
            Hashtable ht = new Hashtable();
            ht.Add("SiteLinkId", request.SiteLinkId);
            BuildSiteLinkRequest(request, ht);
            DataSources.Default.ExecuteNonQuery("EditSiteLink", null, null, ht);
        }

        private static void BuildSiteLinkRequest(AddSiteLinkRequest request, Hashtable ht)
        {
            ht.Add("ChannelId", request.ChannelId);
            ht.Add("LinkUrl", request.LinkUrl);
            ht.Add("Name", request.Name);
        }

        public static void DeleteSiteLink(int siteLinkId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("SiteLinkId", siteLinkId);
            DataSources.Default.ExecuteNonQuery("DeleteSiteLink", null, null, ht);
        }

        public static List<SiteLinkResponse> GetSiteLinkList(SiteLinkQuery query)
        {
            Hashtable ht = new Hashtable();
            List<StatementCondition> list = new List<StatementCondition>();
            if (query.SiteLinkIds != null & query.SiteLinkIds.Count > 0)
            {
                ht.Add("SiteLinkIds", DbUtils.ToWhereInParam(query.SiteLinkIds));
                list.Add(new StatementCondition("SiteLinkIds", true));
            }
            if (query.ChannelId.HasValue)
            {
                ht.Add("ChannelId", query.ChannelId.Value);
                list.Add(new StatementCondition("ChannelId", true));
            }
            if (!string.IsNullOrEmpty(query.Name))
            {
                ht.Add("Name", query.Name);
                list.Add(new StatementCondition("Name", true));
            }
            return DataSources.Default.QueryCollection<SiteLinkResponse>("GetSiteLink", null, list, ht).ToList();
        }

        public static SiteLinkResponse GetSiteLink(int siteLinkId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("SiteLinkId", siteLinkId);
            List<StatementCondition> list = new List<StatementCondition>();
            list.Add(new StatementCondition("SiteLinkId", true));
            return DataSources.Default.Query<SiteLinkResponse>("GetSiteLink", null, list, ht);
        }
        #endregion

        #region 关于我们
        public static int AddAboutUs(AddAboutUsRequest request)
        {
            Hashtable ht = new Hashtable();
            ht.Add("CreatorId", request.CreatorId);
            ht.Add("CreatedTime", DataSources.CurrentTime);
            BuildAboutUsRequest(request, ht);
            return Convert.ToInt32(DataSources.Default.ExecuteScalar("AddAboutUs", null, null, ht));
        }

        public static void EditAboutUs(EditAboutUsRequest request)
        {
            Hashtable ht = new Hashtable();
            ht.Add("AboutUsId", request.AboutUsId);
            ht.Add("UpdaterId", request.UpdaterId);
            ht.Add("UpdatedTime", DataSources.CurrentTime);
            BuildAboutUsRequest(request, ht);
            DataSources.Default.ExecuteNonQuery("EditAboutUs", null, null, ht);
        }

        private static void BuildAboutUsRequest(AddAboutUsRequest request, Hashtable ht)
        {
            ht.Add("Content", request.Content);
            ht.Add("Name", request.Name);
            ht.Add("Title", request.Title);
        }

        public static void DeleteAboutUs(int aboutUsId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("AboutUsId", aboutUsId);
            DataSources.Default.ExecuteNonQuery("DeleteAboutUs", null, null, ht);
        }

        public static List<AboutUsResponse> GetAboutUsList()
        {
            Hashtable ht = new Hashtable();
            List<StatementCondition> list = new List<StatementCondition>();
            return DataSources.Default.QueryCollection<AboutUsResponse>("GetAboutUs", null, list, ht).ToList();
        }

        public static AboutUsResponse GetAboutUs(int aboutUsId)
        {
            Hashtable ht = new Hashtable();
            ht.Add("AboutUsId", aboutUsId);
            List<StatementCondition> list = new List<StatementCondition>();
            list.Add(new StatementCondition("AboutUsId", true));
            return DataSources.Default.Query<AboutUsResponse>("GetAboutUs", null, list, ht);
        }

        public static AboutUsResponse GetAboutUs(string name)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Name", name);
            List<StatementCondition> list = new List<StatementCondition>();
            list.Add(new StatementCondition("Name", true));
            return DataSources.Default.Query<AboutUsResponse>("GetAboutUs", null, list, ht);
        }
        #endregion
    }
}
