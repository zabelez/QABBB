using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.Link;

namespace QABBB.Domain.Services
{
    public class LinkServices
    {
        private readonly QABBBContext _context;
        private readonly LinkRepository _linkRepository;

        public LinkServices(QABBBContext context) {
            _context = context;
            _linkRepository = new LinkRepository(_context);
        }

        public List<Link> list() {
            return _linkRepository.list();
        }

        public Link? findById(int id) {
            return _linkRepository.findById(id);
        }

        public bool add(Link link) {
            return _linkRepository.add(link) ? true : false;
        }

        public bool edit(Link link){
            return _linkRepository.edit(link);
        }

        public bool delete(Link link){
            return _linkRepository.delete(link);
        }

        public ICollection<Link> editProject(ICollection<Link> links, List<LinkInputDTOForPutProject>? inputLinks)
        {
            foreach (var item in links.Select((value, index) => new { value, index }))
            {
                if (!inputLinks.Exists(x => x.IdLink == item.value.IdLink))
                    links.Remove(item.value);
            }

            foreach (LinkInputDTOForPutProject item in inputLinks)
            {
                if (item.IdLink == 0)
                {
                    Link? pd = this.findById(item.IdLink);
                    if (pd != null)
                        links.Add(pd);
                }
            }

            return links;
        }
    }
}

