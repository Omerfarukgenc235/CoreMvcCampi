using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message2>
    {
        public List<Message2> GetInboxByWriter(int id);
        public List<Message2> GetSendboxByWriter(int id);


    }
}
