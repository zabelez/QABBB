using QABBB.API.Models.Link;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class LinkAssembler
    {

        public LinkDTO toLinkDTO(Link link) {

            LinkDTO linkDTO = new LinkDTO();
            linkDTO.IdLink = link.IdLink;
            linkDTO.Type = link.IdLinkTypeNavigation.Name;
            linkDTO.Label = link.Label;
            linkDTO.Url = link.Url;
            
            return linkDTO;
        }

        public Link toLink(Link link, LinkEditDTO linkEditInputDTO){
            link.IdLink = linkEditInputDTO.IdLink;
            link.IdProject = linkEditInputDTO.IdProject;
            link.Label = linkEditInputDTO.Label;
            link.Url = linkEditInputDTO.Url;

            return link;
        }

        public List<LinkDTO> toLinkDTO(IEnumerable<Link> companies) {

            List<LinkDTO> linkDTO = new List<LinkDTO>();

            foreach (Link link in companies) {
                linkDTO.Add(toLinkDTO(link));
            }

            return linkDTO;
        }

        public Link toLink(LinkInputDTO linkInputDTO) {

            Link link = new Link();
            link.IdProject = linkInputDTO.IdProject;
            link.Label = linkInputDTO.Label;
            link.Url = linkInputDTO.Url;

            return link;
        }
    }
}

