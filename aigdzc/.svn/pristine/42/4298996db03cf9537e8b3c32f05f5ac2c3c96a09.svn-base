using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Config
{
    public class AddRegionRequest
    {
        public string Name { get; set; }

        public int ParentId { get; set; }

        public int SortNumber { get; set; }
    }

    public class EditRegionRequest : AddRegionRequest
    {
        public int RegionId { get; set; }
    }

    public class RegionQuery
    {
        public RegionQuery()
        {
            RegionIds = new List<int>();
        }
        public List<int> RegionIds { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
    }

    public class AddRoundPlayRequest
    {
        public string ImageUrl { get; set; }

        public int ChannelId { get; set; }

        public int AssociatedArticleId { get; set; }
    }

    public class EditRoundPlayRequest : AddRoundPlayRequest
    {
        public int RoundPlayId { get; set; }
    }

    public class RoundPlayQuery
    {
        public RoundPlayQuery()
        {
            RoundPlayIds = new List<int>();
        }

        public List<int> RoundPlayIds { get; set; }

        public int? ChannelId { get; set; }

        public int? AssociatedArticleId { get; set; }

        public int? ShowCount { get; set; }
    }

    public class AddSiteLinkRequest
    {
        public string Name { get; set; }

        public string LinkUrl { get; set; }

        public int ChannelId { get; set; }
    }

    public class EditSiteLinkRequest: AddSiteLinkRequest
    {
        public int SiteLinkId { get; set; }
    }

    public class SiteLinkQuery
    {
        public SiteLinkQuery()
        {
            SiteLinkIds = new List<int>();
        }

        public List<int> SiteLinkIds { get; set; }

        public int? ChannelId { get; set; }

        public string Name { get; set; }
    }

    public class AddAboutUsRequest
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CreatorId { get; set; }
    }

    public class EditAboutUsRequest: AddAboutUsRequest
    {
        public int AboutUsId { get; set; }

        public int UpdaterId { get; set; }
    }
}
